using MultiShop.DtoLayer.BasketDtos;

namespace MultiShop.WebUI.Services.BasketServices
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket();
        Task Savebasket(BasketTotalDto basketTotalDto);
        Task Deletebasket(string userId);
        Task AddBasketItem(BasketItemDto basketItemDto);
        Task<bool> RemoveBasketItem(string productId);
    }
}
