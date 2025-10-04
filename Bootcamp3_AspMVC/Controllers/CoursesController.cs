using Bootcamp3_AspMVC.Data;
using Bootcamp3_AspMVC.Interfaces;
using Bootcamp3_AspMVC.Models;
using Bootcamp3_AspMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp3_AspMVC.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IRepository<Course> _courseRepository;
      
        public CoursesController(IRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;

            //var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            //    .UseSqlServer("Server=DESKTOP-L71NKL9\\MSSQLSERVERR;Database=BootCampThree;User Id=sa;Password=123;TrustServerCertificate=True;")
            //    .Options;
            //var context = new ApplicationDbContext(options);
            //_courseRepository = new MainRepository<Course>(context);
        }

        public IActionResult Index()
        {
            var courses = _courseRepository.GetAll();
            return View(courses);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
     
        public IActionResult Create(Course course)
        {


            try
            {

                if (!ModelState.IsValid)
                {

                    return View(course);
                }

                _courseRepository.Add(course);
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

            var cate = _courseRepository.GetByUid(Uid);
            return View(cate);
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult Edit(Course course)
        {

            if (!ModelState.IsValid)
            {
                return View(course);
            }

            _courseRepository.Update(course);
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public IActionResult Delete(string Uid)
        {
            var cate = _courseRepository.GetByUid(Uid);
            return View(cate);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostDelete(string Uid)
        {
            
            var cate = _courseRepository.GetByUid(Uid);
            if (cate != null)
            {
       
                _courseRepository.Delete(cate.Id);

            }

            return RedirectToAction(nameof(Index));
        }



    }
}
