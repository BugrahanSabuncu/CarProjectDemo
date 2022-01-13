using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
    public static class ClaimExtensions
    {
        public static void AddEmail(this ICollection<Claim> claims,string email) //var olan bir yapıya metot ekliyoruz.
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));//jwtregister var olan bölümleri getirir.
        }
        public static void AddName(this ICollection<Claim> claims, string name) //var olan bir yapıya metot ekliyoruz.
        {
            claims.Add(new Claim(ClaimTypes.Name, name));//jwtregister var olan bölümleri getirir.
        }
        public static void AddNameIdentfier(this ICollection<Claim> claims, string nameIdentifier) //var olan bir yapıya metot ekliyoruz.
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));//jwtregister var olan bölümleri getirir.
        }
        public static void AddRoles(this ICollection<Claim> claims, string[] roles) //var olan bir yapıya metot ekliyoruz.
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role))); //jwtregister var olan bölümleri getirir.
        }
    }
}
