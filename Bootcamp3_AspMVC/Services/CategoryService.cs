using Bootcamp3_AspMVC.Interfaces;
using Bootcamp3_AspMVC.Interfaces.IServices;
using Bootcamp3_AspMVC.Models;

namespace Bootcamp3_AspMVC.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }




        public bool Create(Category category)
        {
            _unitOfWork._categoryRepository.Add(category);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool DeleteByUid(string uid)
        {
            var category = _unitOfWork._categoryRepository.GetByUid(uid);
            if (category == null)
            {
                return false;
            }
            _unitOfWork._categoryRepository.Delete(category.Id);
            _unitOfWork.SaveChanges();
            return true;

        }

        public IEnumerable<Category> GetAll()
        {
            return _unitOfWork._categoryRepository.GetAll();

        }

        public Category? GetByUid(string uid)
        {
            return _unitOfWork._categoryRepository.GetByUid(uid);
        }


        public bool Update(string uid, Category input)
        {
            var category = _unitOfWork._categoryRepository.GetByUid(uid);
            if (category == null)
            {
                return false;
            }
            category.Name = input.Name;
            category.Description = input.Description;
            _unitOfWork._categoryRepository.Update(category);
            _unitOfWork.SaveChanges();
            return true;

        }

    }
}
