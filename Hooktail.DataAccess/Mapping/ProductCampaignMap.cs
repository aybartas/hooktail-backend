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
    public class ProductCampaignMap : IEntityTypeConfiguration<ProductCampaign>
    {
        public void Configure(EntityTypeBuilder<ProductCampaign> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.HasOne(I => I.Product).WithMany(I => I.ProductCampaigns).HasForeignKey(I => I.ProductId);
            builder.HasOne(I => I.Campaign).WithMany(I => I.ProductCampaigns).HasForeignKey(I => I.CampaignId);
        
        }
    }
}
