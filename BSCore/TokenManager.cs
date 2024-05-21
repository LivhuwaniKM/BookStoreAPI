using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BSCore
{
    public class TokenManager
    {
        private const int EXPIRATION_IN_MINUTES = 20;
        private const string SECRET_KEY = "JKAJKDJkdD@*&*@#JKAJDKDJKWE677263726372";
        private readonly SymmetricSecurityKey SIGNING_KEY = new(Encoding.UTF8.GetBytes(SECRET_KEY));
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor httpContextAccessor;

        public TokenManager() { }

        public TokenManager(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            this.configuration = configuration;
            this.httpContextAccessor = httpContextAccessor;
        }

        public SymmetricSecurityKey GetSigningKey
        {
            get { return SIGNING_KEY; }
        }

        private string GenerateJwtToken()
        {
            var claims = new List<Claim>()
            {
                new (ClaimTypes.Name, "John Doe"),
                new (ClaimTypes.Role, "Developer"),
                new (JwtRegisteredClaimNames.Sub, "1234")
            };

            var credentials = new SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256Signature);

            var description = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = configuration["baseurl:Issuer"],
                Audience = configuration["baseurl:Audience"],
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(EXPIRATION_IN_MINUTES),
                SigningCredentials = credentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(description);
            return tokenHandler.WriteToken(token);
        }

        private void AddTokenValueToSession(string token)
        {
            if (httpContextAccessor.HttpContext != null && token != null)
            {
                byte[] tokenBytes = Encoding.UTF8.GetBytes(token);

                httpContextAccessor.HttpContext.Session.Set("SecurityToken", tokenBytes);
            }
        }

        private static bool ValidateTokenIsNotNullOrEmpty(string token)
        {
            if (!string.IsNullOrEmpty(token))
                return true;
            else
                return false;
        }

        public string? GetJwtToken()
        {
            var token = GenerateJwtToken();

            if (ValidateTokenIsNotNullOrEmpty(token))
            {
                AddTokenValueToSession(token);
                return token;
            }
            return null;
        }
    }
}
