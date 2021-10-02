using Hooktail.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hooktail.DataAccess.Mapping
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Content).HasMaxLength(500).IsRequired();
            builder.HasOne(I => I.Product).WithMany(I => I.Comments).HasForeignKey(I => I.ProductId);
            builder.HasOne(I => I.User).WithMany(I => I.Comments).HasForeignKey(I => I.UserId);
            builder.HasOne(I => I.ParentComment).WithMany(I => I.SubComments).HasForeignKey(I => I.ParentCommentId);

        }
    }
}
