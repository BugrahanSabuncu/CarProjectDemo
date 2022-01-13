using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Core.Utilities.Security.Ecyption;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Core.Extensions;
using System.Linq;
namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; set; } //appsettings içini okumaya yarar.
        TokenOptions _tokenOptions;//appsettings'e karşılık gelen nesnem
        DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            //appsettings'te olan bilgileri tokenOptions içine atıyorum.Get<> otomatik map yapıyor.
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken()
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
            

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken //aslında bütün olay bunu üretmek üzerine kurulu
                (
                issuer: tokenOptions.Issuer,
                expires: _accessTokenExpiration,
                audience: tokenOptions.Audience,
                notBefore: DateTime.Now, //geçerliliği şu andan önce olamaz
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
                );
            
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user,List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentfier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            return claims;         
            
            
            //claims.Add(new Claim("email", user.Email)); //Bu şekilde ekleme yapılabilir.Fakat profesyonel değildir.
        }
    }
}
