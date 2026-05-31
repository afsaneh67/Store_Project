using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Persistance.Configurations
{
    public class UserRoleConfigration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(x => new {x.RoleId,x.UserId});
            builder.HasOne(x=>x.User).WithMany(x=>x.UserRole).HasForeignKey(x=>x.UserId);
            builder.HasOne(x => x.Role).WithMany(x => x.UserRole).HasForeignKey(x => x.RoleId);
            builder.ToTable("UserRoles");
        }
    }
}
