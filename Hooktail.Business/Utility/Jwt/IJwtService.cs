using Hooktail.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hooktail.Business.Utility.Jwt
{
    public interface IJwtService
    {
        string GenerateJwt(User user, List<Role> userRoles);
    }
}
