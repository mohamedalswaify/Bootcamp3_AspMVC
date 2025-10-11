using Microsoft.AspNetCore.Mvc;

namespace Bootcamp3_AspMVC.Controllers
{
    public class HomeEmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
