using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultCommentDto>> CommentListByProductId(string id)
        {
            var value = await _httpClient.GetFromJsonAsync<List<ResultCommentDto>>("comments/CommentListByProductId/" + id);
            return value;
        }

        public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCommentDto>("comments",createCommentDto);
        }

        public async Task DeleteCommentAsync(string id)
        {
            await _httpClient.DeleteAsync("comments/" + id);
        }

        public async Task<List<ResultCommentDto>> GetAllCommentAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultCommentDto>>("comments");
            return values;
        }

        public async Task<UpdateCommentDto> GetByIdCommentAsync(string id)
        {
            var value = await _httpClient.GetFromJsonAsync<UpdateCommentDto>("comments/" + id);
            return value;
        }

        public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCommentDto>("comments", updateCommentDto);
        }
    }
}
