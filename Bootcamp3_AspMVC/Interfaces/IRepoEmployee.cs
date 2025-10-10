using Bootcamp3_AspMVC.Models;

namespace Bootcamp3_AspMVC.Interfaces
{
    public interface IRepoEmployee : IRepository<Employee>
    {
        IEnumerable<Employee> GetEmployeesWithDeptAndJob();


    }
}
