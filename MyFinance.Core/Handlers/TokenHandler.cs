using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using MyFinance.Core.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Core.Handlers
{
    public class TokenHandler
    {
        private static Config config = new Config();

        public static string GenerateToken(Usuario usuario)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(config.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.Now.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                IssuedAt = DateTime.UtcNow,
                Issuer = "MyFinanceAPI",
                Audience = "MyFinanceAPP"
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
