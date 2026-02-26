using System;

namespace SieMarket.Models
{
    public class OrderItem
    {
        public Guid Id {get; set; } = Guid.NewGuid();
        public string ProductName {get; set; }
        public int Quantity {get; set; }
        public decimal UnitPrice { get; set;}

        public OrderItem(string productName, int quantity, decimal unitPrice)
        {
            if (quantity <= 0) throw new ArgumentException("Quantity must be greater than zero");
            if (unitPrice < 0) throw new ArgumentException("Unit price cannot be negative");

            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        //Totalul per produs
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}