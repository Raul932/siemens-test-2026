using SieMarket.Interfaces;
using SieMarket.Models;

namespace SieMarket.Services
{
    public class DiscountService : IDiscountService
    {
        private const decimal DiscountThreshold = 500m;
        private const decimal DiscountRate = 0.10m;

        public decimal CalculateDiscount(Order order, decimal subtotal)
        {
            if (subtotal > DiscountThreshold)
            {
                return subtotal * DiscountRate;
            }
            return 0m;
        }
    }
}