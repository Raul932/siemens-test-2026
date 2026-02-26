using SieMarket.Models;

namespace SieMarket.Interfaces
{
    public interface IDiscountService
    {
        decimal CalculateDiscount(Order order, decimal subtotal);
    }
}