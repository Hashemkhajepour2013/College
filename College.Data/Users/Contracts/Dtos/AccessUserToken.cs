using System.IdentityModel.Tokens.Jwt;

namespace College.Services.JWT.Contracts.Dto
{
    public class AccessUserToken
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }

        public AccessUserToken(JwtSecurityToken securityToken)
        {
            access_token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            token_type = "Bearer";
            expires_in = (int)(securityToken.ValidTo - DateTime.UtcNow).TotalSeconds;
        }
    }
}
