namespace MultiShop.SignalRRealTimeApi.Services.SignalRMessageServices
{
    public class SignalRMessageService : ISignalRMessageService
    {
        private readonly HttpClient _httpClient;

        public SignalRMessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalMessageCountByReceiverId(string id)
        {
            var value = await _httpClient.GetFromJsonAsync<int>("usermessages/GetTotalMessageCountByReceiverId?id=" + id);
            return value;
        }
    }
}
