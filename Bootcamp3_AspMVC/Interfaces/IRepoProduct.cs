using Bootcamp3_AspMVC.Models;

namespace Bootcamp3_AspMVC.Interfaces
{
    public interface IRepoProduct : IRepository<Product>
    {

        IEnumerable<Product> GetProductsWithCategory();


    }
}
