﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateNewOrder(Order order);
    }
}
