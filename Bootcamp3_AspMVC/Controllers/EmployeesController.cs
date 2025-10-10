using Bootcamp3_AspMVC.Data;
using Bootcamp3_AspMVC.Interfaces;
using Bootcamp3_AspMVC.Models;
using Bootcamp3_AspMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp3_AspMVC.Controllers
{

    public class EmployeesController : Controller
    {

       // private readonly ApplicationDbContext _context;
        //private readonly IRepoEmployee _employeeRepository;
        //private readonly IRepository<Department> _deptRepository;
        //private readonly IRepository<Job> _jobRepository;


        //public EmployeesController( IRepoEmployee employeeRepository, IRepository<Department> deptRepository, IRepository<Job> jobRepository)
        //{
        //  //  _context = context;
        //    _employeeRepository = employeeRepository;
        //    _deptRepository = deptRepository;
        //    _jobRepository = jobRepository;
        //}

        private readonly IUnitOfWork _unitOfWork;
        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        private void Createdepts(int selected = 0)
        {
           // IEnumerable<Department> depts = _context.Departments.ToList();
            IEnumerable<Department> depts = _unitOfWork._deptRepository.GetAll();
            SelectList selectListItems = new SelectList(depts, "Id", "Name", selected);
            ViewBag.deptsList = selectListItems;
        }

        private void CreateJobs(int selected = 0)
        {
           // IEnumerable<Job> depts = _context.Jobs.ToList();
            IEnumerable<Job> depts = _unitOfWork._jobRepository.GetAll();
            SelectList selectListItems = new SelectList(depts, "Id", "Name", selected);
            ViewBag.JobsList = selectListItems;
        }



        [HttpGet]
        public IActionResult Index()
        {
            //IEnumerable<Employee> emps = _context.Employees
            //    .Include(e => e.Department)
            //    .Include(e => e.Job)
            //    .ToList();
            var emps = _unitOfWork._employeeRepository.GetEmployeesWithDeptAndJob();
            return View(emps);
        }



        [HttpGet]
        public IActionResult Create()
        {
            Createdepts();
            CreateJobs();
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



                //_context.Employees.Add(emp);
                //_context.SaveChanges();

                _unitOfWork._employeeRepository.Add(emp);
                _unitOfWork.SaveChanges();



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
            //var emp = _context.Employees.Find(Id);
            var emp = _unitOfWork._employeeRepository.GetById(Id);

            Createdepts();
            CreateJobs();
            return View(emp);
        }



        [HttpPost]
        public IActionResult Edit(Employee emp)
        {

            if (!ModelState.IsValid)
            {
                return View(emp);
            }

            //_context.Employees.Update(emp);
            //_context.SaveChanges();
            _unitOfWork._employeeRepository.Update(emp);
            _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {

            //var emp = _context.Employees.Find(Id);
            var emp = _unitOfWork._employeeRepository.GetById(Id);
            return View(emp);
        }



        [HttpPost]
        public IActionResult Delete(Employee emp)
        {
            //_context.Employees.Remove(emp);
            //_context.SaveChanges();
            _unitOfWork._employeeRepository.Delete(emp.Id);
            _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }





    }
}
