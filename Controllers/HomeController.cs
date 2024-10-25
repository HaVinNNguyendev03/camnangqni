    using camnangqni.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using Microsoft.AspNetCore.Authorization;
using camnangqni.Models.ViewModel;


namespace camnangqni.Controllers
    {
        public class HomeController : Controller
        {
            private readonly ILogger<HomeController> _logger;
            private readonly IConfiguration _configuration;

            public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
            {
                _logger = logger;
                _configuration = configuration;
            }
        
            public IActionResult Index()
            {
            if (HttpContext.Items["UserID"] == null)
            {
              return RedirectToAction("Index", "Auth");
            }
            var userid = HttpContext.Items["UserID"] as string;
            var username = HttpContext.Items["UserName"] as string;
            var useremail = HttpContext.Items["UserEmail"] as string;
            String[] datatoken = new string[3];
            datatoken[0] = userid;
            datatoken[1] = username;
            datatoken[2] = useremail;
            var layoutData = new LayoutViewModel {
                  UserID = userid,
                  Username = username,
                  UserEmail = useremail
            };
            ViewData["LayoutData"] = layoutData;
                return View();
            }

        public IActionResult Privacy()
        {
            return View();
        }
      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
