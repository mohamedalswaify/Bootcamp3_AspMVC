using Bootcamp3_AspMVC.Models;

namespace Bootcamp3_AspMVC.Interfaces.IServices
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        Category? GetByUid(string uid);
        bool Create(Category category);
        bool Update(string uid, Category input);
        bool DeleteByUid(string uid);

    }
}
