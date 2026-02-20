using BaratoInventory.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaratoInventory.Infrastructure.Services
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options): base(options)
        {
        }
        public DbSet<PsDocLin> PsDocLin { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PsDocLin>()
            .HasKey(p => new { p.DOC_ID, p.LIN_SEQ_NO });

            modelBuilder.Entity<PsDocLin>()
                .Property(p => p.LIN_SEQ_NO)
                .ValueGeneratedNever();
            base.OnModelCreating(modelBuilder);

    
        }
    }
}
