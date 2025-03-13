using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderAddressServices
{
    public interface IOrderAddressServices
    {
        //Task<List<ResultOrderDto>> GetAllOrderAsync();
        Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto);
        //Task UpdateOrderAsync(UpdateOrderDto updateOrderDto);
        //Task DeleteOrderAsync(string id);
        //Task<UpdateOrderDto> GetByIdOrderAsync(string id);
    }
}
