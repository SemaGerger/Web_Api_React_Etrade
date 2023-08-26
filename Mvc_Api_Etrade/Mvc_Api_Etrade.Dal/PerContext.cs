using Microsoft.EntityFrameworkCore;
using Mvc_Api_Etrade.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc_Api_Etrade.Dal
{
    public class PerContext :DbContext
    {
        public PerContext(DbContextOptions<PerContext> db) : base(db)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasketDetail>()
                .HasKey(b => new { b.BasketId, b.ProductId });
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<BasketMaster> Baskets { get; set; }
        public DbSet<BasketDetail> BasketDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
      

    }
}
