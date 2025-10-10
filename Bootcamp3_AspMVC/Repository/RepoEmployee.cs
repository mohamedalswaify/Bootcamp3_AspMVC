using Bootcamp3_AspMVC.Data;
using Bootcamp3_AspMVC.Interfaces;
using Bootcamp3_AspMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp3_AspMVC.Repository
{
    public class RepoEmployee : MainRepository<Employee>, IRepoEmployee
    {
        private readonly ApplicationDbContext _context;
        public RepoEmployee(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetEmployeesWithDeptAndJob()
        {
          return  _context.Employees
               .Include(e => e.Department)
               .Include(e => e.Job)
               .ToList();

        }



    }
}
