
namespace MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices
{
    public class MessageStatisticService : IMessageStatisticService
    {
        private readonly HttpClient _httpClient;

        public MessageStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalMessageCount()
        {
            var value = await _httpClient.GetFromJsonAsync<int>("usermessages/GetTotalMessageCount");
            return value;
        }
    }
}
