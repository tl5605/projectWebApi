using Entities;
using DTOs;
using AutoMapper;
using System.Collections.Generic;

namespace projectWebApi
 
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            //CreateMap<List<Product>, List<ProductDto>>().ReverseMap();
            CreateMap<UserLoginDto, User>();
            CreateMap<Category, CategoryDto>().ReverseMap();
            //CreateMap<List<Category>, List<CategoryDto>>().ReverseMap();
        }
    }
}
