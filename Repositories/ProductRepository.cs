using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;


namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        private _326134715ShopContext _context;

        public ProductRepository(_326134715ShopContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProducts(int? minPrice, int? maxPrice, int?[] categoryIds, string? description)
        {
            var query = _context.Products.Where(product =>
                (minPrice == null ? (true) : (product.Price >= minPrice))
                && (maxPrice == null ? (true) : (product.Price <= maxPrice))
                && (description == null ? (true) : (product.Description.Contains(description)))
                && ((categoryIds.Length == 0 || categoryIds[0]== null) ? (true) : (categoryIds.Contains(product.CategoryId))))
                .OrderBy(product => product.Price);

            List<Product> products = await query.ToListAsync();
            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}
