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
    public class SubCategoryMap : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Name).IsRequired();
            builder.HasOne(I => I.Category).WithMany(I => I.SubCategories).HasForeignKey(I => I.CategoryId);
            builder.HasMany(I => I.Products).WithOne(I => I.SubCategory).HasForeignKey(I => I.SubCategoryId);

        }
    }
}
