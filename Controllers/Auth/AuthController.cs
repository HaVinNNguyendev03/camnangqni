using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace camnangqni.Controllers.Auth
{
    public class AuthController : Controller
    {
        private readonly CamnangDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(CamnangDbContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpGet]
        [Route("auth/checkdb")]
        public async Task<IActionResult> CheckDatabaseConnection()
        {
            try
            {
                // Kiểm tra kết nối bằng cách truy vấn một bảng (Ví dụ: bảng Users)
                var canConnect = await _context.Users.AnyAsync();
                return Content("Kết nối đến cơ sở dữ liệu thành công.");
            }
            catch (DbUpdateException ex)
            {
                return Content($"Lỗi kết nối đến cơ sở dữ liệu: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Content($"Lỗi không xác định: {ex.Message}");
            }
        }
        // GET: AuthController
        [Route("auth/home")]
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Signin(Users model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingUser = await _context.Users
                    .FirstOrDefaultAsync(u => u.UserEmail == model.UserEmail);
                    if (existingUser != null)
                    {
                        ModelState.AddModelError("UserEmail", "Email này đã tồn tại.");
                        return View("Register", model);
                    }
                    var newUser = new Users
                    {
                        Username = model.Username,
                        UserEmail = model.UserEmail,
                        UserPassWord = model.UserPassWord,
                        CreatedAt = DateTime.Now,
                        IsActive = model.IsActive,
                        UserRule = model.UserRule
                    };
                    _context.Users.Add(newUser);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Auth");

                }
                return View("Index", model);
            }
            catch (System.Exception)
            {

                ModelState.AddModelError(string.Empty, "Đã xảy ra lỗi. Vui lòng thử lại.");
                return View("Index", model);
            }

        }
        [HttpPost]
        [Route("auth/login")]
        public async Task<IActionResult> Signup(string email, string password)
        {
            var users = await _context.Users.FirstOrDefaultAsync(u => u.UserEmail == email && u.UserPassWord == password);
            if (users != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("wdiGao8JyfyooEFfehcTLcLK-LGub3YoGKHkVa-ZuZQ=");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                new Claim(ClaimTypes.NameIdentifier, users.UserID.ToString()),
                new Claim(ClaimTypes.Email, users.UserEmail),
                new Claim(ClaimTypes.Name, users.Username)
            }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                Response.Cookies.Append("jwtToken", tokenString, new CookieOptions
                {
                    HttpOnly = false, // Không thể truy cập từ JavaScript
                    Secure = false,   // Chỉ gửi cookie qua HTTPS
                    SameSite = SameSiteMode.Strict, // Bảo vệ chống CSRF
                    Expires = DateTimeOffset.UtcNow.AddMinutes(5) // Thời gian hết hạn
                });
                return Ok(new { Token = tokenString });
            }

            // Nếu thông tin đăng nhập không đúng, trả về mã lỗi và thông báo
            return BadRequest(new { Message = "Email hoặc mật khẩu không đúng." });
        }

        [HttpPost]
        [Route("auth/logout")]
        public IActionResult Logout()
        {
            // Xóa cookie xác thực (nếu bạn đã sử dụng cookie)
            Response.Cookies.Delete("jwtToken");
            return RedirectToAction("Index", "Auth");
        }
    }
}
