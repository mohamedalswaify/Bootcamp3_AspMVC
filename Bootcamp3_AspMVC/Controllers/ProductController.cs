using Bootcamp3_AspMVC.Data;
using Bootcamp3_AspMVC.Filters;
using Bootcamp3_AspMVC.Interfaces;
using Bootcamp3_AspMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp3_AspMVC.Controllers
{
    [SessionAuthorize]
    public class ProductController : Controller
    {

        private readonly IRepoProduct _productRepository;

        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context, IRepoProduct productRepository)
        {
            _context = context;
            _productRepository = productRepository;

        }



        [HttpGet]
        public IActionResult Index()
        {
            //IEnumerable<Product> products =
            //    _context.Products
            //    .Include(p => p.Category)
            //    .ToList();


            var products2 = _productRepository.GetProductsWithCategory();

            return View(products2);
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
        [ValidateAntiForgeryToken]
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
        public IActionResult Edit(string Uid)
        {
            var category = _context.Products.SingleOrDefault(e=>e.Uid ==Uid);
            CreateCategory();
          //  category.Uid = Guid.NewGuid().ToString();
          ////  _context.Products.Update(category);
          //  _context.SaveChanges();
            return View(category);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product ,string Uid)
        {
            if (Uid != product.Uid)
            {
                return NotFound();
            }


            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var category = _context.Products.SingleOrDefault(e => e.Uid == product.Uid);

            if (category == null)
            {
                return NotFound();
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
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }













    }
}
