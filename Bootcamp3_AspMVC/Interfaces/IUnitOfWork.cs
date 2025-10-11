using Bootcamp3_AspMVC.Models;

namespace Bootcamp3_AspMVC.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
         IRepoEmployee _employeeRepository { get; }
        IRepository<Department> _deptRepository { get; }
        IRepository<Job> _jobRepository { get; }

        IRepository<Category> _categoryRepository { get; }

        void SaveChanges();

    }
}
