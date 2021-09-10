using Hooktail.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hooktail.DataAccess.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Username).HasMaxLength(50).IsRequired();
            builder.Property(I => I.Password).HasMaxLength(50).IsRequired();
            builder.HasMany(I => I.Comments).WithOne(I => I.User).HasForeignKey(I => I.UserId);
            builder.HasMany(I => I.Orders).WithOne(I => I.User).HasForeignKey(I => I.UserId);
            builder.HasMany(I => I.PaymentInfos).WithOne(I => I.User).HasForeignKey(I => I.UserId);
        }
    }
}


