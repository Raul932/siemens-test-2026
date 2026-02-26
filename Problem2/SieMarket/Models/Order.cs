using System;
using System.Collections.Generic;

namespace SieMarket.Models
{
    public class Order
    {
        public Guid Id {get; set; } = Guid.NewGuid();
        public string CustomerName {get; set; }
        public DateTime OrderDate {get; set; } = DateTime.UtcNow;
        public List<OrderItem> Items {get; set; } = new List<OrderItem>();

        public Order(string CustomerName)
        {
            if (string.IsNullOrWhiteSpace(CustomerName))
                throw new ArgumentException("Name required");

            CustomerName = CustomerName;
        }

    }
}