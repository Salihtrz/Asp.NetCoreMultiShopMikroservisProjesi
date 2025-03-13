using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultInboxMessageDto>>("http://localhost:5000/services/Message/UserMessages/GetMessageInbox?id=" + id);
            return values;
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultSendboxMessageDto>>("http://localhost:5000/services/Message/UserMessages/GetMessageSendbox?id=" + id);
            return values;
        }

        public async Task<int> GetTotalMessageCountByReceiverId(string id)
        {
            var value = await _httpClient.GetFromJsonAsync<int>("usermessages/GetTotalMessageCountByReceiverId?id=" + id);
            return value;
        }
    }
}
