using Bootcamp3_AspMVC.Data;
using Bootcamp3_AspMVC.Interfaces;
using Bootcamp3_AspMVC.Interfaces.IServices;
using Bootcamp3_AspMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp3_AspMVC.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {

                IEnumerable<Category> categories = _categoryService.GetAll();
                return View(categories);

            }
            catch (Exception)
            {

                throw;
            }

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
            if (!ModelState.IsValid) return View(category);
            _categoryService.Create(category);
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult Edit(string Uid)
        {
            var cate = _categoryService.GetByUid(Uid);
            return View(cate);
        }




        [HttpPost]
       // [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
       
            if (!ModelState.IsValid) return View(category);
            _categoryService.Update(category.Uid, category);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Delete(string Uid)
        {
            var cate =_categoryService.GetByUid(Uid);
            return View(cate);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostDelete(string Uid)
        {
           _categoryService.DeleteByUid(Uid);
            return RedirectToAction(nameof(Index));
        }






    }
}
