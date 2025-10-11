using Bootcamp3_AspMVC.Data;
using Bootcamp3_AspMVC.Interfaces;
using Bootcamp3_AspMVC.Models;

namespace Bootcamp3_AspMVC.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _employeeRepository = new RepoEmployee(_context);
            _deptRepository = new MainRepository<Department>(_context);
            _jobRepository = new MainRepository<Job>(_context);
            _categoryRepository = new MainRepository<Category>(_context);

        }


     public   IRepoEmployee _employeeRepository { get; }
     public IRepository<Department> _deptRepository { get; }
     public  IRepository<Job> _jobRepository { get; }
        public IRepository<Category> _categoryRepository { get; }

        public void Dispose()
        {
            _context.Dispose();

        }

        public void SaveChanges()
        {
            _context.SaveChanges();

        }
    }
}
