using System.Linq;
using SieMarket.Interfaces;
using SieMarket.Models;

namespace SieMarket.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IDiscountService _discountService;

        public OrderService(IOrderRepository orderRepository, IDiscountService discountService)
        {
            _orderRepository = orderRepository;
            _discountService = discountService;
        }
        //2.2 solution
        public decimal CalculateFinalPrice(Order order)
        {
            // calculate the subtotal
            decimal subtotal = order.Items.Sum(item => item.TotalPrice);

            // calculate the discount
            decimal discount = _discountService.CalculateDiscount(order, subtotal);

            // return the final price
            return subtotal - discount;
        }
        //2.3
        public string GetTopSpenderName()
        {
            var allOrders = _orderRepository.GetAll();

            if (!allOrders.Any())
            {
                return "No orders found."; // if empty
            }

            var topCustomer = allOrders
                .GroupBy(order => order.CustomerName) // 1. Group by client
                .Select(group => new 
                {
                    CustomerName = group.Key,
                    // 2. Calculate total sum for this customer
                    TotalSpent = group.Sum(order => CalculateFinalPrice(order)) 
                })
                .OrderByDescending(customer => customer.TotalSpent) // 3. Sort decreasing
                .FirstOrDefault(); // 4. We get the first one

            return topCustomer?.CustomerName;
        }
        //2.4
        public Dictionary<string, int> GetPopularProducts()
        {
            var allOrders = _orderRepository.GetAll();

            return allOrders
                .SelectMany(order => order.Items) // 1. Put all items from all orders together
                .GroupBy(item => item.ProductName) // 2. Group them by their name
                .OrderByDescending(group => group.Sum(item => item.Quantity)) // 3. Sort decreasing by quantity sold
                .ToDictionary(
                    group => group.Key,                       // The key will be the name
                    group => group.Sum(item => item.Quantity) // Value will be total quantity
                );
        }

        public void ProcessAndSaveOrder(Order order)
        {
            decimal finalPrice = CalculateFinalPrice(order);
            _orderRepository.Save(order);
            System.Console.WriteLine($"[OrderService] Order for {order.CustomerName} processed. Final Price: {finalPrice}€");
        }
    }
}