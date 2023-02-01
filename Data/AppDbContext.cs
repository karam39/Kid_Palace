using Kid_PalaceA2.Models.ProductM;
using Kid_PalaceA2.Models.Supplier;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using SLE_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kid_PalaceA2.Models
{
    public class AppDbContext : IdentityDbContext
    {
        private readonly DbContextOptions _options;

        public AppDbContext(DbContextOptions options) : base(options)
        {
            _options = options; 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<ToyModel> Products2 { get; set; }
        public DbSet<ProductCatagory> ProductCategory { get; set; }
        public DbSet<SupplierDetail> SupplierDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
       public DbSet<OrderItem> OrderItems { get; set; }
       public DbSet<RecievingAddress> RecievingAddresses { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    
    }
}
