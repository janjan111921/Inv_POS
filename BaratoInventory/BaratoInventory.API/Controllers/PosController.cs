using BaratoInventory.Core.DTOs;
using BaratoInventory.Core.Interface;
using BaratoInventory.Core.Models;
using BaratoInventory.Infrastructure.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaratoInventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PosController : ControllerBase
    {
        private readonly IPosService _posService;

        public PosController(IPosService posService)
        {
            _posService = posService;
        }

        [HttpPost("create-transaction")]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionRequest request)
        {
            // Simple Input Validation
            if (request == null || !request.Items.Any())
                return BadRequest("Transaction must contain at least one item.");

            // Call the Service Layer
            var result = await _posService.CreateTransactionAsync(request);

            if (!result.Success)
            {
                // Return 400 for business logic errors, or 500 for DB crashes
                return result.Message.Contains("not found")
                    ? BadRequest(result.Message)
                    : StatusCode(500, "An internal error occurred.");
            }

            return Ok(new { Message = "Transaction processed successfully." });
        }
    }
}
