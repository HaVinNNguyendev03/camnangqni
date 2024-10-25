using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace camnangqni.Controllers.Auth
{
    public class Jwt
    {
        private readonly RequestDelegate _next;
        private readonly string _secretKey;

        public Jwt(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _secretKey = configuration["JwtSettings:SecretKey"];
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Cookies["jwtToken"];

            if (!string.IsNullOrEmpty(token) && ValidateJwtToken(token, out var userId,out var userName,out var userEmail))
            {
                // Gắn thông tin người dùng vào context nếu token hợp lệ
                context.Items["UserID"] = userId;
                context.Items["UserName"] = userName;
                context.Items["UserEmail"] = userEmail;
            }
            await _next(context);
        }

        private bool ValidateJwtToken(string token, out string userId,out string userName, out string userEmail)
        {
            userId = null;
            userName = null;
            userEmail = null;
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("wdiGao8JyfyooEFfehcTLcLK-LGub3YoGKHkVa-ZuZQ=");

                var parameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.FromMinutes(5),    
                };

                var claims = tokenHandler.ValidateToken(token, parameters, out _);
                userId = claims.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                userName = claims.FindFirst(ClaimTypes.Name)?.Value;
                userEmail = claims.FindFirst(ClaimTypes.Email)?.Value;
                return userId != null;
            }
            catch
            {
                // Token không hợp lệ hoặc có lỗi xảy ra
                return false;
            }
        }
    }
}
