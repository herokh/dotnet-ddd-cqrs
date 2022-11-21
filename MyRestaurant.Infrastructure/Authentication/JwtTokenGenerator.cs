using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using MyRestaurant.Application.Common.Interfaces.Authentication;
using Microsoft.IdentityModel.Tokens;
using MyRestaurant.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;
using MyRestaurant.Domain.Entities;

namespace MyRestaurant.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _JwtSettings;
    private readonly IDateTimeProvider _datetimeProvider;

    public JwtTokenGenerator(IDateTimeProvider datetimeProvider,
        IOptions<JwtSettings> jwtOptions)
    {
        _datetimeProvider = datetimeProvider;
        _JwtSettings = jwtOptions.Value;
    }

    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_JwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256
        );

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
        };

        var securityToken = new JwtSecurityToken(
            issuer: _JwtSettings.Issuer,
            audience: _JwtSettings.Audience,
            expires: _datetimeProvider.UtcNow.AddMinutes(_JwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}


