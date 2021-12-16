using Hooktail.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hooktail.DataAccess.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Name).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Price).IsRequired();
            builder.HasOne(I => I.SubCategory).WithMany(I => I.Products).HasForeignKey(I => I.SubCategoryId);
            builder.HasOne(I => I.Stock).WithOne(I => I.Product);
            builder.HasMany(I => I.ProductCampaigns).WithOne(I => I.Product).HasForeignKey(I => I.ProductId);
            builder.HasMany(I => I.OrderItems).WithOne(I => I.Product).HasForeignKey(I => I.ProductId);
            builder.HasMany(I => I.Comments).WithOne(I => I.Product).HasForeignKey(I => I.ProductId);
            builder.Navigation(x => x.SubCategory).AutoInclude();

        }
    }
}
