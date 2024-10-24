using Microsoft.AspNetCore.Mvc;

namespace camnangqni.Controllers.Product
{
    public class IndexController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
