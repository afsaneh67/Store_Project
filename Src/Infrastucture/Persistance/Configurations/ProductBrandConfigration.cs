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
    internal class ProductBrandConfigration : IEntityTypeConfiguration<ProductBrand>
    {
        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.Title).HasMaxLength(100);
            builder.Property(x => x.Summary).HasMaxLength(100);
            //builder.HasQueryFilter(x => x.IsDelete == false);

            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.CreateBY);
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.LastModifiedBY);

        }
    }
}
