using Bootcamp3_AspMVC.Data;
using Bootcamp3_AspMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp3_AspMVC.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;

        }



        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Employee> emps = _context.Employees.ToList();
            return View(emps);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(Employee emp)
        {


            try
            {

                if (!ModelState.IsValid)
                {

                    return View(emp);
                }



                _context.Employees.Add(emp);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return Content("حدث  خطا غير متوقع يرجي الاتصال بالدعم الفني.");
            }
        }
        //-------------------------------------------------------------------------------------------------


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var emp = _context.Employees.Find(Id);
            return View(emp);
        }



        [HttpPost]
        public IActionResult Edit(Employee emp)
        {

            if (!ModelState.IsValid)
            {
                return View(emp);
            }

            _context.Employees.Update(emp);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {

            var emp = _context.Employees.Find(Id);
            return View(emp);
        }



        [HttpPost]
        public IActionResult Delete(Employee emp)
        {
            _context.Employees.Remove(emp);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }





    }
}
