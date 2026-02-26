using System;
using System.Collections.Generic;
using SieMarket.Models;

namespace SieMarket.Interfaces
{
    public interface IOrderRepository
    {
        void Save(Order order);
        Order GetById(Guid id);
        IEnumerable<Order> GetAll();
    }
}