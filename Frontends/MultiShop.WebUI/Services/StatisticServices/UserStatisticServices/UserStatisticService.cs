
using MultiShop.DtoLayer.IdentityDtos.UserDtos;

namespace MultiShop.WebUI.Services.StatisticServices.UserStatisticServices
{
    public class UserStatisticService : IUserStatisticService
    {
        private readonly HttpClient _httpClient;

        public UserStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetUserCount()
        {
            var values = await _httpClient.GetFromJsonAsync<int>("http://localhost:5002/api/Statistics");
            return values;
        }
    }
}
