using MultiShop.DtoLayer.IdentityDtos.UserDtos;

namespace MultiShop.WebUI.Services.UserIdentityService
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly HttpClient _httpClient;

        public UserIdentityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultUserDto>> GetAllUserListAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultUserDto>>("http://localhost:5002/api/users/GetAllUserList");
            return values;
        }
    }
}
