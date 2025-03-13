using MultiShop.WebUI.Services.StatisticServices.DiscountStatisticService;

namespace MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices
{
    public class DiscountStatisticService : IDiscountStatisticService
    {
        private readonly HttpClient _httpClient;

        public DiscountStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetDiscountCouponCount()
        {
            var value = await _httpClient.GetFromJsonAsync<int>("discounts/GetDiscountCouponCount");
            return value;
        }
    }
}
