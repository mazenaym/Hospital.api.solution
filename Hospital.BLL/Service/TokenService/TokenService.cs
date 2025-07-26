using Microsoft.Extensions.Configuration;
using Hospital.DAL.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.Service.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;
        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<string> CreateTokenAsync(Appuser user)
        {
            var claims = new List<Claim>
            {
              new Claim("userId", user.Id),
              new Claim("email", user.Email),
              new Claim(ClaimTypes.Role, user.usertype),
              new Claim("fullname", user.fullname),

                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:Issuer"],
                audience: configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: creds

            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
