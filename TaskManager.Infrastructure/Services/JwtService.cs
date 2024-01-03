using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        public static readonly string Secret = "5V-6MZad=*+9qITp!%Ee7?a5!qQm2p4rHe%Ejg2*J4@EZ#@U67";
        public static string Audience = "TaskManager";
        private readonly int ExpirationDayCount = 3;

        public string GenerateJwt(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtService.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = JwtService.Audience,
                IssuedAt = DateTime.Now,
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("nameid", user.UserId.ToString()),
                    new Claim("given_name", user.Email.ToString()),
                    new Claim("unique_name", $"{user.UserName}"),
                }),

                Expires = DateTime.UtcNow.AddDays(this.ExpirationDayCount),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public int GetExpirationDayCount()
        {
            return this.ExpirationDayCount;
        }
    }
}

