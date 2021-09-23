using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hooktail.Business.StaticInfo.Jwt
{
    public static class JwtInfo
    {
        public const string Issuer = "https://localhost:44396";
        public const string Audience = "https://localhost:44396"; // CHANGE AFTER CLIENT
        public const string SecurityKey = "thisismysecretkey";

    }
}
