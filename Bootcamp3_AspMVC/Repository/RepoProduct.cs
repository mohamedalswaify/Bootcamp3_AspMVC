using Bootcamp3_AspMVC.Data;
using Bootcamp3_AspMVC.Interfaces;
using Bootcamp3_AspMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp3_AspMVC.Repository
{
    public class RepoProduct : MainRepository<Product>, IRepoProduct
    {
        private readonly ApplicationDbContext _context;
        public RepoProduct(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProductsWithCategory()
        {
            return _context.Products
                .Include(p => p.Category)
                .ToList();

        }
    }
}
