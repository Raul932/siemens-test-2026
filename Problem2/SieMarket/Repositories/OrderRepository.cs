using System;
using System.Collections.Generic;
using System.Linq;
using SieMarket.Interfaces;
using SieMarket.Models;

namespace SieMarket.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _database = new List<Order>();

        public void Save(Order order)
        {
            _database.Add(order);
            Console.WriteLine($"[Database] Order {order.Id} saved successfully.");
        }

        public Order GetById(Guid id)
        {
            return _database.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _database;
        }
    }
}