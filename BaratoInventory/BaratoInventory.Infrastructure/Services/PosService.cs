using BaratoInventory.Core.Common;
using BaratoInventory.Core.DTOs;
using BaratoInventory.Core.Interface;
using BaratoInventory.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaratoInventory.Infrastructure.Services
{
    public class PosService:IPosService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<PosService> _logger;

        public PosService(AppDbContext context, ILogger<PosService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ServiceResponse> CreateTransactionAsync(CreateTransactionRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Fetch all products in ONE query (Bulk Lookup)
                var itemNos = request.Items.Select(i => i.ItemNo).Distinct().ToList();

                var products = await _context.PsDocLin
                    .AsNoTracking()
                    .Where(p => itemNos.Contains(p.ITEM_NO))
                    .GroupBy(p => p.ITEM_NO)
                    .Select(g => g.OrderByDescending(x => x.LIN_GUID).FirstOrDefault()) 
                    .ToDictionaryAsync(p => p.ITEM_NO);

                //  Get the current max sequence
                int sequenceCounter = await _context.PsDocLin
                    .Where(l => l.DOC_ID == request.DocId)
                    .MaxAsync(l => (int?)l.LIN_SEQ_NO) ?? 0;

                var newLines = new List<PsDocLin>();

                foreach (var item in request.Items)
                {
                    if (!products.TryGetValue(item.ItemNo, out var product))
                    {
                        return new ServiceResponse { Success = false, Message = $"Product {item.ItemNo} not found." };
                    }

                    sequenceCounter++;

                    newLines.Add(new PsDocLin
                    {
                        DOC_ID = request.DocId,
                        LIN_SEQ_NO = sequenceCounter,
                        STR_ID = request.StrId,
                        STA_ID = request.StaId,
                        TKT_NO = request.TktNo,
                        ITEM_NO = item.ItemNo,
                        DESCR = product.DESCR,
                        PRC = product.PRC ?? 0,
                        QTY_SOLD = item.QtySold,
                        EXT_PRC = item.QtySold * (product.PRC ?? 0),
                        UNIT_COST = product.UNIT_COST ?? 0,
                        EXT_COST = item.QtySold * (product.UNIT_COST ?? 0),
                        LIN_GUID = Guid.NewGuid(),
                        LIN_TYP = "L"
                       
                    });
                }

                _context.PsDocLin.AddRange(newLines);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return new ServiceResponse { Success = true };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "Transaction failed for DocId {DocId}", request.DocId);
                return new ServiceResponse { Success = false, Message = "Internal Database Error." };
            }
        }
    }
}
