using Hooktail.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hooktail.DataAccess.Mapping
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Quantity).IsRequired();
            builder.HasOne(I => I.Product).WithMany(I => I.OrderItems).HasForeignKey(I => I.ProductId);
            builder.HasOne(I => I.Order).WithMany(I => I.OrderItems).HasForeignKey(I => I.OrderId);
       
        }
    }
}
