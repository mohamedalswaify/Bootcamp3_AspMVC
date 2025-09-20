using Bootcamp3_AspMVC.Data;
using Bootcamp3_AspMVC.Filters;
using Bootcamp3_AspMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp3_AspMVC.Controllers
{
    [SessionAuthorize]
    public class ProductController : Controller
    {



        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;

        }



        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Product> products =
                _context.Products
                .Include(p => p.Category)
                .ToList();

            return View(products);
        }

        private void CreateCategory(int selected =0)
        {
            IEnumerable<Category> categories = _context.Categories.ToList();
            SelectList selectListItems = new SelectList(categories, "Id", "Name", selected);
            ViewBag.CategoryList = selectListItems;
        }


        [HttpGet]
        public IActionResult Create()
        {

            CreateCategory();
            return View();

        }



        [HttpPost]
        public IActionResult Create(Product product)
        {


            try
            {

                if (!ModelState.IsValid)
                {

                    return View(product);
                }



                _context.Products.Add(product);
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
            var category = _context.Products.Find(Id);
            CreateCategory();
            return View(category);
        }



        [HttpPost]
        public IActionResult Edit(Product product)
        {

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {

            var category = _context.Products.Find(Id);
            return View(category);
        }



        [HttpPost]
        public IActionResult Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }













    }
}
