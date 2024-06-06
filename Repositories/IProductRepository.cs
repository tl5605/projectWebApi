﻿using Entities;

namespace Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts(int? minPrice, int? maxPrice, int?[] categoryIds, string? productName);

        Task<Product> GetProductById(int id);
    }

}
