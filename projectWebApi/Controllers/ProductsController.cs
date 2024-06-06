using Microsoft.AspNetCore.Mvc;
using Entities;
using Services;
using DTOs;
using AutoMapper;

namespace projectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        private IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAllProduct([FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categoryIds, [FromQuery] string? description)
        {

            List<Product> product =await _productService.GetAllProducts(minPrice, maxPrice, categoryIds, description);

            if (product == null)
                return NotFound();
            List<ProductDto> productsDto = _mapper.Map<List<Product>, List<ProductDto>>(product);
            return Ok(productsDto);
        }

    }
}
