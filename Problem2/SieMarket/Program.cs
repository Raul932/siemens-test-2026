using System;
using System.Linq;
using SieMarket.Models;
using SieMarket.Services;
using SieMarket.Repositories;

namespace SieMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================================================");
            Console.WriteLine("       SIEMARKET ORDER PROCESSING SYSTEM          ");
            Console.WriteLine("==================================================\n");
            Console.ResetColor();

            var repository = new OrderRepository();
            var discountService = new DiscountService();
            var orderService = new OrderService(repository, discountService);


            // Order 1 : No discount
            var order1 = new Order("Raul");
            order1.Items.Add(new OrderItem("Tastatura Mecanica", 1, 150m));
            order1.Items.Add(new OrderItem("Mouse Wireless", 1, 50m));

            // Order 2 : 10% discount
            var order2 = new Order("Raul");
            order2.Items.Add(new OrderItem("Laptop Gaming", 1, 1000m));

            // Order 3 : 10% discount
            var order3 = new Order("Maria");
            order3.Items.Add(new OrderItem("Monitor 4K", 1, 600m));
            order3.Items.Add(new OrderItem("Mouse Wireless", 2, 50m));

            orderService.ProcessAndSaveOrder(order1);
            orderService.ProcessAndSaveOrder(order2);
            orderService.ProcessAndSaveOrder(order3);
            Console.WriteLine();


            // TESTING 2.2
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(">>> 2.2: Discount rule");
            Console.ResetColor();
            
            Console.WriteLine($"- Small order (200€) {orderService.CalculateFinalPrice(order1)}€");
            Console.WriteLine($"- Big order (1000€) {orderService.CalculateFinalPrice(order2)}€ (10% applied)\n");


            // TESTING 2.3
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(">>> 2.3: Top spender");
            Console.ResetColor();
            
            string topSpender = orderService.GetTopSpenderName();
            Console.WriteLine($"- The top spender is: {topSpender}\n");


            // TESTING 2.4
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(">>> 2.4: Popular products");
            Console.ResetColor();
            
            var popularProducts = orderService.GetPopularProducts();
            foreach (var kvp in popularProducts)
            {
                Console.WriteLine($"- Product: {kvp.Key.PadRight(20)} | Sold: {kvp.Value}");
            }
            
            Console.WriteLine("\n==================================================");
        }
    }
}