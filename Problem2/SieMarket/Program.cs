using System;
using SieMarket.Models;
using SieMarket.Services;
using SieMarket.Repositories;

namespace SieMarket
{
    class Program
    {
        static void Main(string[] args)
        {

            var repository = new OrderRepository();
            var discountService = new DiscountService();
            var orderService = new OrderService(repository, discountService);

            var order1 = new Order("Raul");
            order1.Items.Add(new OrderItem("Mouse", 1, 150m));
            var order2 = new Order("Raul");
            order2.Items.Add(new OrderItem("Laptop", 1, 1000m));
            var order3 = new Order("Maria");
            order3.Items.Add(new OrderItem("TV OLED", 1, 2000m)); 
            orderService.ProcessAndSaveOrder(order1);
            orderService.ProcessAndSaveOrder(order2);
            orderService.ProcessAndSaveOrder(order3);

            Console.WriteLine("\nCalculare Top Spender");
            string topSpender = orderService.GetTopSpenderName();
            
            Console.WriteLine($"Clientul care a cheltuit cei mai multi bani este: {topSpender}");
        }
    }
}