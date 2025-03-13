
using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices
{
    public class CommentStatisticService : ICommentStatisticService
    {
        private readonly HttpClient _httpClient;

        public CommentStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetActiveCommentCount()
        {
            var value = await _httpClient.GetFromJsonAsync<int>("comments/GetActiveCommentCount");
            return value;
        }

        public async Task<int> GetPassiveCommentCount()
        {
            var value = await _httpClient.GetFromJsonAsync<int>("comments/GetPassiveCommentCount");
            return value;
        }

        public async Task<int> GetTotalCommentCount()
        {
            var value = await _httpClient.GetFromJsonAsync<int>("comments/GetTotalCommentCount");
            return value;
        }
    }
}
