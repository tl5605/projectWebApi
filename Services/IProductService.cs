using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts(int? minPrice, int? maxPrice, int?[] categoryIds, string? productName);
    }
}
