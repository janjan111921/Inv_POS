using BaratoInventory.Core.Interface;
using BaratoInventory.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaratoInventory.Infrastructure.Repositories
{
    public class Queries: IQueries
    {
        private readonly AppDbContext _appDbContext;
        public Queries(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

    }
}
