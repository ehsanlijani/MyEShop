using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyEShop.Application.Services.Interfaces;
using MyEShop.Domain.Entities.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyEShop.Application.Services.Implementations;

public class TokenService(IConfiguration configuration) : ITokenService
{

    private readonly SymmetricSecurityKey _key = new(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

    public string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim("UserId",user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.NameId,user.Email)
        };

        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
            configuration["Jwt:Issuer"],
            claims,
            expires: DateTime.Now.AddDays(7),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

