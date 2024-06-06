using Microsoft.AspNetCore.Mvc;
using Entities;
using Services;
using DTOs;
using System.Collections.Generic;
using AutoMapper;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        
        private ICategoryService _ctegoriesServiec;
        private IMapper _mapper;
        public CategoriesController(ICategoryService ctegoriesServiec, IMapper mapper)
        {
            _ctegoriesServiec = ctegoriesServiec;
            _mapper = mapper;
        }

        [HttpGet]
        public  async Task<ActionResult<List<CategoryDto>>> Get()
        {
            List<Category> categories = await _ctegoriesServiec.GetAllCategories();
            if (categories == null)
                return NotFound();
            List<CategoryDto> categoriesDto = _mapper.Map<List<Category>, List<CategoryDto>>(categories);

            return Ok(categoriesDto);
        }

    }
}
