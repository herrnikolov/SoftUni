using FDMC.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FDMC.Data
{
    public class FDMCContext : DbContext
    {        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Database=Cats;Integrated Security=True");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Cat> Cats { get; set; }
    }
}
