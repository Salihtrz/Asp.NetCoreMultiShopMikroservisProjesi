using MultiShop.Basket.Dtos;

namespace MultiShop.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket(string userId);
        Task Savebasket(BasketTotalDto basketTotalDto);
        Task Deletebasket(string userId);
    }
}
