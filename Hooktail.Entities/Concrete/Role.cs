using Hooktail.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hooktail.Entities.Concrete
{
    public class Role: ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}
