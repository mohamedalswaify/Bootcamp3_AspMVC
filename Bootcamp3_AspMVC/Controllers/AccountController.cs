using Bootcamp3_AspMVC.Data;
using Bootcamp3_AspMVC.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp3_AspMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(EmployeeDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var employee = _context.Employees.FirstOrDefault(e =>e.Email==dto.email && e.Password ==dto.password);
            if (employee != null)
            {
                if(employee.TypeUser==1)
                {
                    HttpContext.Session.SetString("email", employee.Email);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    HttpContext.Session.SetString("email", employee.Email);
                    return RedirectToAction("Index", "HomeEmployee");
                }

              
            }
            return View();
        }

    }
}
