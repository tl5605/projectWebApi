﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repositories;
using Services;


namespace Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository; 
        }

        public async Task<List<Product>> GetAllProducts(int? minPrice, int? maxPrice, int?[] categoryIds, string? description)
        {
            return await _productRepository.GetAllProducts(minPrice, maxPrice, categoryIds, description);
        }
    }
}
