using Hooktail.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hooktail.DataAccess.Mapping
{
    public class PaymentInfoMap : IEntityTypeConfiguration<PaymentInfo>
    {
        public void Configure(EntityTypeBuilder<PaymentInfo> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.PaymentType).HasMaxLength(100).IsRequired();
            builder.Property(I => I.CardNumber).HasMaxLength(30).IsRequired();
            builder.HasOne(I => I.User).WithMany(I => I.PaymentInfos).HasForeignKey(I => I.UserId);

        }
    }
}
