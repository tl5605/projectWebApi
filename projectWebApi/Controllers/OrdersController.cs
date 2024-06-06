using Microsoft.AspNetCore.Mvc;
using Entities;
using Services;
using AutoMapper;
using DTOs;

namespace projectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderService _ordersService;
        private IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _ordersService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OrderDto orderDto)
        {
            Order order = _mapper.Map<OrderDto, Order>(orderDto);
            Order newOrder = await _ordersService.CreateNewOrder(order);
            if (newOrder != null)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
