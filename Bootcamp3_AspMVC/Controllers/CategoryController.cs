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
       // [ValidateAntiForgeryToken]
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
        public IActionResult Edit(string Uid)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Uid == Uid);
            //category.Uid = Guid.NewGuid().ToString();
            //_context.SaveChanges();
            return View(category);
        }


        //[HttpGet]
        //public IActionResult Edit(int Id)
        //{
        //    var category = _context.Categories.Find(Id);
        //    if (category != null)
        //    {
        //        return View(category);
        //    }
        //    return RedirectToAction("Index");
        //}


        [HttpPost]
       // [ValidateAntiForgeryToken]
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
        public IActionResult Delete(string Uid)
        {

            var category = _context.Categories.FirstOrDefault(c => c.Uid == Uid);
            return View(category);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostDelete(string Uid)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Uid == Uid);
            if(category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
               
            }

            return RedirectToAction(nameof(Index));
        }






    }
}
