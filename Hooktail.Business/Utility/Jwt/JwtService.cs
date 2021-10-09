using Hooktail.Business.StaticInfo.Jwt;
using Hooktail.Entities.Concrete;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hooktail.Business.Utility.Jwt
{
    public class JwtService : IJwtService
    {
        public string GenerateJwt(User user,List<Role> userRoles)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.SecurityKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenHandler = new JwtSecurityTokenHandler();

            var jwtSecurityToken = new JwtSecurityToken(
                issuer:JwtInfo.Issuer,
                audience:JwtInfo.Audience,
                notBefore:DateTime.Now,
                expires:DateTime.Now.AddDays(JwtInfo.Expires),
                claims: GetClaims(user,userRoles),
                signingCredentials: credentials
                );

            return tokenHandler.WriteToken(jwtSecurityToken);
        }
        private List<Claim> GetClaims(User user, List<Role> userRoles)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            if (userRoles.Count > 0)
            {            
                foreach(var role in userRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role,role.Name));
                }
            }
            return claims;
        }
    }
}
