using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private _326134715ShopContext _context;

        public OrderRepository(_326134715ShopContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateNewOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
