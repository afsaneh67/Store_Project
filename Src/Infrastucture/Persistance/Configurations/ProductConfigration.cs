using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Persistance.Configurations
{
    public class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.PictureUrl).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.Title).HasMaxLength(100);
            builder.Property(x => x.Summary).HasMaxLength(100);

            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.CreateBY);
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.LastModifiedBY);
            builder.HasOne(x=>x.productType).WithMany().HasForeignKey(x=>x.TypeId);
            builder.HasOne(x => x.productBrand).WithMany().HasForeignKey(x => x.BrandId);
        }
        
    }
}
