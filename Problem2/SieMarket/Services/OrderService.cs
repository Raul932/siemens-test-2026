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

        public decimal ProcessOrder(Order order)
        {
            //we calculate the subtotal
            decimal subtotal = order.Items.Sum(item => item.TotalPrice);
            //then the discount
            decimal discount = _discountService.CalculateDiscount(order, subtotal);

            //the final
            decimal finalTotal = subtotal - discount;

            //after that, we save the order
            _orderRepository.Save(order);

            return finalTotal;
        }
    }
}