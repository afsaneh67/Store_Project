using Application.Interfaces;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Infrastucture.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration configuration, UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSetting:Key"]));
        }

        public async Task<string> CreateToken(User user)
        {
            if (user.PhoneNumber == null) return null;
            var claims = new List<Claim>()
            {
                new (JwtRegisteredClaimNames.GivenName,user.DisplayName ?? ""),
                new (JwtRegisteredClaimNames.NameId,user.Id ?? ""),
                new ("PhoneNumber",user.PhoneNumber ?? "")
            };

            var roles=await _userManager.GetRolesAsync(user);
            if (roles!=null && roles.Any())
                claims.AddRange(roles.Select(r=>new Claim(ClaimTypes.Role,r)));

            var cred=new SigningCredentials(_key,SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = _configuration["JwtSetting:Issuer"],
                Audience = _configuration["JwtSetting:Audience"],
                IssuedAt = DateTime.Now,
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = cred,
                Subject=new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token= tokenHandler.CreateToken(tokenDescriptor);
            return await Task.Run(()=>tokenHandler.WriteToken(token)).ConfigureAwait(false);

        }

    }
}
