using Bootcamp3_AspMVC.Data;
using Bootcamp3_AspMVC.Interfaces;
using Bootcamp3_AspMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp3_AspMVC.Controllers
{
    public class CategoryOldController : Controller
    {


        private readonly ApplicationDbContext _context;
       // private readonly IRepository<Category> _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;


        public CategoryOldController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
           // _categoryRepository = repository;
            _context = context;
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public IActionResult Index()
        {
          //  IEnumerable<Category> categories = _context.Categories.ToList();
            IEnumerable<Category> categories = _unitOfWork._categoryRepository.GetAll() ;
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



                //_context.Categories.Add(category);
                //_context.SaveChanges();

                _unitOfWork._categoryRepository.Add(category);
                _unitOfWork.SaveChanges();  

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
           // var category = _context.Categories.FirstOrDefault(c => c.Uid == Uid);
            var cate = _unitOfWork._categoryRepository.GetByUid(Uid);
            //category.Uid = Guid.NewGuid().ToString();
            //_context.SaveChanges();
            return View(cate);
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

            var cate = _unitOfWork._categoryRepository.GetByUid(category.Uid);
            if (cate == null)
            {
                return NotFound();
            }


            //_context.Categories.Update(category);
            //_context.SaveChanges();

            cate.Name = category.Name;
            cate.Description = category.Description;
            _unitOfWork._categoryRepository.Update(cate);
            _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Delete(string Uid)
        {

           // var category = _context.Categories.FirstOrDefault(c => c.Uid == Uid);
            var cate = _unitOfWork._categoryRepository.GetByUid(Uid);
            return View(cate);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostDelete(string Uid)
        {
           // var category = _context.Categories.FirstOrDefault(c => c.Uid == Uid);
            var cate = _unitOfWork._categoryRepository.GetByUid(Uid);
            if (cate != null)
            {
                //_context.Categories.Remove(category);
                //_context.SaveChanges();

                _unitOfWork._categoryRepository.Delete(cate.Id);
                _unitOfWork.SaveChanges();

            }

            return RedirectToAction(nameof(Index));
        }






    }
}
