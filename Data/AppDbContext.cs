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
			this.SeedUsers(modelBuilder);

		}

		private void SeedUsers(ModelBuilder builder)
		{
			IdentityUser user = new IdentityUser()
			{
				UserName = "Admin786@",
				NormalizedUserName= "ADMIN786@",
				Email = "Admin786@gmail.com",
				NormalizedEmail= "ADMIN786@GMAIL.COM",
				LockoutEnabled = false,
				PhoneNumber = "1234567890",
				EmailConfirmed = true,
				PasswordHash = "AQAAAAEAACcQAAAAEFGtqJilD57Kq/kozZHxkL2eJSJufl9jxXT5oqmVQFOX6+yO0p6qopF51pTc721GTA=="

			};

			PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
			passwordHasher.HashPassword(user, "Admin786@");

			builder.Entity<IdentityUser>().HasData(user);
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
