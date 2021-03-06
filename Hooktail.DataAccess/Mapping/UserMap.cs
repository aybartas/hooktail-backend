using Hooktail.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            builder.HasIndex(I => I.Username).IsUnique();  // to make username unique
            builder.HasMany(I => I.UserRoles).WithOne(I => I.User).
                HasForeignKey(I => I.UserId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}


