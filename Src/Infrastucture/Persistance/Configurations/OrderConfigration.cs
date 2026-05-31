using Domain.Entities.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Persistance.Configurations
{
    public class OrderConfigration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.OwnsOne(x => x.ShipToAddress, a => a.WithOwner());
            builder.HasMany(x=>x.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.DeliveryMethod).WithMany();
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.CreateBY);
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.LastModifiedBY);

        }
    }
}
