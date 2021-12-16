using Hooktail.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hooktail.DataAccess.Mapping
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.HasOne(I => I.User).WithMany(I => I.Orders).HasForeignKey(I => I.UserId);
            builder.HasMany(I => I.OrderItems).WithOne(I => I.Order).HasForeignKey(I => I.OrderId);

        }
    }
}
