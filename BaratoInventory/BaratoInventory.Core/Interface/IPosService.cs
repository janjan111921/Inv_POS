using BaratoInventory.Core.Common;
using BaratoInventory.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaratoInventory.Core.Interface
{
    public interface IPosService
    {
         Task<ServiceResponse> CreateTransactionAsync(CreateTransactionRequest request);
    }
}
