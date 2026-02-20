using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaratoInventory.Core.DTOs
{
    public class CreateTransactionRequest
    {
        public long DocId { get; set; }
        public string StrId { get; set; } = null!;
        public string StaId { get; set; } = null!;
        public string TktNo { get; set; } = null!;

        public List<TransactionItemDto> Items { get; set; } = new();
    }
    public class TransactionItemDto
    {
        public string ItemNo { get; set; } = null!;
        public decimal QtySold { get; set; }
    }
}
