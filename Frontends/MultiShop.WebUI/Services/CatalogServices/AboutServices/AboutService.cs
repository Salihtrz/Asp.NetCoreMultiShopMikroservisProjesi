using MultiShop.DtoLayer.CatalogDtos.AboutDtos;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly HttpClient _httpClient;

        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            await _httpClient.PostAsJsonAsync<CreateAboutDto>("abouts", createAboutDto);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _httpClient.DeleteAsync("abouts/" + id);
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
            return values;
        }

        public async Task<UpdateAboutDto> GetByIdAboutAsync(string id)
        {
            var value = await _httpClient.GetFromJsonAsync<UpdateAboutDto>("abouts/" + id);
            return value;
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateAboutDto>("abouts", updateAboutDto);
        }
    }
}
