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
namespace camnangqni.Controllers.User
{
    public class UserController : Controller
    {
        private readonly CamnangDbContext _context;
        private readonly IConfiguration _configuration;

        public UserController(CamnangDbContext context,IConfiguration configuration)
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
        // GET: UserController
        [Route("/usersmanager")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
