using Bootcamp3_AspMVC.Data;
using Bootcamp3_AspMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp3_AspMVC.Controllers
{
    public class CategoryController : Controller
    {


        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;

        }


        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _context.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(Category category)
        {


            try
            {

                if (!ModelState.IsValid) { 
                
                return View(category);
                }



                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return Content("حدث  خطا غير متوقع يرجي الاتصال بالدعم الفني.");
            }
        }



        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var category = _context.Categories.Find(Id);
            return View(category);
        }



        [HttpPost]
        public IActionResult Edit(Category category)
        {

            if (!ModelState.IsValid)
            {
                return View(category);
            }

            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {

            var category = _context.Categories.Find(Id);
            return View(category);
        }



        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }






    }
}
