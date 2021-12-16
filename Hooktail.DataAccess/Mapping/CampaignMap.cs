using Hooktail.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hooktail.DataAccess.Mapping
{
    public class CampaignMap : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Name).HasMaxLength(100);
            builder.Property(I => I.DiscountPercentage).IsRequired();
            builder.HasMany(I => I.ProductCampaigns).WithOne(I => I.Campaign).HasForeignKey(I => I.CampaignId);

        }
    }
}
