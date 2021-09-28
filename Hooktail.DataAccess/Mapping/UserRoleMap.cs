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
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            // to prevent more than one userid and roleid pair at same time
            builder.HasIndex(I => new { I.UserId, I.RoleId }).IsUnique();
        }
    }
}
