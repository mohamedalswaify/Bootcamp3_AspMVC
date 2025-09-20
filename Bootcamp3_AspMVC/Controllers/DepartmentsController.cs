using Bootcamp3_AspMVC.Data;
using Bootcamp3_AspMVC.Filters;
using Bootcamp3_AspMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp3_AspMVC.Controllers
{
    [SessionAuthorize]
    public class DepartmentsController : Controller
    {


        private readonly ApplicationDbContext _context;

        public DepartmentsController(ApplicationDbContext context)
        {
            _context = context;

        }



        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Department>  depts = _context.Departments.ToList();
            return View(depts);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(Department dept)
        {


            try
            {

                if (!ModelState.IsValid)
                {

                    return View(dept);
                }



                _context.Departments.Add(dept);
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
            var dept = _context.Departments.Find(Id);
            return View(dept);
        }



        [HttpPost]
        public IActionResult Edit(Department dept)
        {

            if (!ModelState.IsValid)
            {
                return View(dept);
            }

            _context.Departments.Update(dept);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {

            var dept = _context.Departments.Find(Id);
            return View(dept);
        }



        [HttpPost]
        public IActionResult Delete(Department dept)
        {
            _context.Departments.Remove(dept);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }










    }
}
