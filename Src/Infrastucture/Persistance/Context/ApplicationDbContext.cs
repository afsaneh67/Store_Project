using Domain.Entities.Identity;
using Domain.Entities.Order;
using Domain.Entities.Product;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Persistance.Context
{
    public class ApplicationDbContext :IdentityDbContext<User,Domain.Entities.Identity.Role,string,
        IdentityUserClaim<string>,UserRole,
        IdentityUserLogin<string>,
        IdentityRoleClaim<string>,
        IdentityUserToken<string>
        >//DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //public DbSet<Product> Products { get; set; }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductBrand> productBrands => Set<ProductBrand>();
        public DbSet<ProductType> productTypes => Set<ProductType>();
        public DbSet<User> User => Set<User>();
        public DbSet<Address> Address => Set<Address>();
        public DbSet<Domain.Entities.Identity.Role> Role => Set<Domain.Entities.Identity.Role>();
        public DbSet<UserRole> UserRole => Set<UserRole>();
        //order
        public DbSet<Orders> Orders => Set<Orders>();
        public DbSet<OrderItem> OrderItem => Set<OrderItem>();
        public DbSet<DeliveryMethod> DeliveryMethod => Set<DeliveryMethod>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasQueryFilter(x => x.IsDelete == false);
            modelBuilder.Entity<ProductType>().HasQueryFilter(x => x.IsDelete == false);
            modelBuilder.Entity<ProductBrand>().HasQueryFilter(x => x.IsDelete == false);
            modelBuilder.Entity<Address>().HasQueryFilter(x => x.IsDelete == false);
            modelBuilder.Entity<Orders>().HasQueryFilter(x => x.IsDelete == false);
            modelBuilder.Entity<OrderItem>().HasQueryFilter(x => x.IsDelete == false);
            modelBuilder.Entity<DeliveryMethod>().HasQueryFilter(x => x.IsDelete == false);

            //تمام کلاسهایی که از IEntityTypeConfiguration ارث بری کنه درنظر میگیره
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
