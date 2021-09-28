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
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.
                HasMany(I => I.UserRoles).
                WithOne(I => I.Role).
                HasForeignKey(I => I.RoleId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
