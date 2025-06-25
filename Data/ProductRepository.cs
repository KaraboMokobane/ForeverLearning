using System.Collections.Generic;
using System.Linq;

namespace ForeverLearning.Data
{
    public class ProductRepository
    {
        private readonly AppDBContext _dbContext;

        public ProductRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Product> GetAllProducts() => _dbContext.Products.ToList();
    }
}
