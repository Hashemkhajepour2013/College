using College.Common;
using College.Entities.Users;
using College.Services.JWT.Contracts;
using College.Services.JWT.Contracts.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace College.Services.JWT
{
    public class JwtService : IJwtService, IScopedDependency
    {
        private readonly SiteSettings _siteSetting;
        private readonly SignInManager<User> _signInManager;
        public JwtService(IOptionsSnapshot<SiteSettings> settings, SignInManager<User> signInManager)
        {
            _siteSetting = settings.Value;
            _signInManager = signInManager;
        }

        public async Task<AccessUserToken> Generate(User user)
        {
            var secretKey = Encoding.UTF8.GetBytes(_siteSetting.jwtSettings.SecretKey);
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(secretKey),
                SecurityAlgorithms.HmacSha256Signature);

            var encryptionkey = Encoding.UTF8.GetBytes(_siteSetting.jwtSettings.Encryptkey);

            var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptionkey), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);
            var claims = await GetClaims(user);
            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = _siteSetting.jwtSettings.Issuer,
                Audience = _siteSetting.jwtSettings.Audience,
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddDays(_siteSetting.jwtSettings.ExpirationDays),
                SigningCredentials = signingCredentials,
                EncryptingCredentials = encryptingCredentials,
                Subject = new ClaimsIdentity(claims)                
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var securityToken = tokenHandler.CreateJwtSecurityToken(descriptor);

            return new AccessUserToken(securityToken);
        }

        private async Task<IEnumerable<Claim>> GetClaims(User user)
        {
            var result = await _signInManager.ClaimsFactory.CreateAsync(user);
            return result.Claims;
        }
    }
}
