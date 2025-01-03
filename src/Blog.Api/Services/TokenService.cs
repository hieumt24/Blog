using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Blog.Core.ConfigOptions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Api.Services;

public class TokenService : ITokenService
{
    private readonly JwtTokenSettings _jwtTokenSettings;
    public TokenService(IOptions<JwtTokenSettings> jwtTokenSettings)
    {
        _jwtTokenSettings = jwtTokenSettings.Value;
    }
    public string GenerateAccessToken(IEnumerable<Claim> claims)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenSettings.Key));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        
        var tokeOptions = new JwtSecurityToken(
            issuer: _jwtTokenSettings.Issuer,
            audience: _jwtTokenSettings.Issuer,
            claims: claims,
            expires: DateTime.Now.AddHours(_jwtTokenSettings.ExpiryInHours),
            signingCredentials: signinCredentials
        );
        
        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        return tokenString;
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
    /// <summary>
    /// Get user principle from expired token
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    /// <exception cref="SecurityTokenException"></exception>
    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenSettings.Key)),
            ValidateLifetime = false
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");
        
        return principal;
    }
}