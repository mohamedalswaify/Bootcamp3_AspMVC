using Bootcamp3_AspMVC.Data;
using Bootcamp3_AspMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp3_AspMVC.Controllers
{
    public class JobsController : Controller
    {


        private readonly ApplicationDbContext _context;

        public JobsController(ApplicationDbContext context)
        {
            _context = context;

        }



        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Job> jobs = _context.Jobs.ToList();
            return View(jobs);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(Job job)
        {


            try
            {

                if (!ModelState.IsValid)
                {

                    return View(job);
                }



                _context.Jobs.Add(job);
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
            var job = _context.Jobs.Find(Id);
            return View(job);
        }



        [HttpPost]
        public IActionResult Edit(Job job)
        {

            if (!ModelState.IsValid)
            {
                return View(job);
            }

            _context.Jobs.Update(job);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {

            var dept = _context.Jobs.Find(Id);
            return View(dept);
        }



        [HttpPost]
        public IActionResult Delete(Job dept)
        {
            _context.Jobs.Remove(dept);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }







    }
}
