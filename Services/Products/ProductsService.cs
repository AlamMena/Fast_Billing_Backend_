using API.DbModels.Contexts;
using System.ComponentModel.DataAnnotations;

namespace API.Services.Products
{
    public class ProductService
    {
        private readonly FbContext _context;
        public ProductService(FbContext context)
        {
            _context = context;
        }

        public bool ProductExistsAsync()
        {
            return _context.Products.Any();
        }
    }
}
