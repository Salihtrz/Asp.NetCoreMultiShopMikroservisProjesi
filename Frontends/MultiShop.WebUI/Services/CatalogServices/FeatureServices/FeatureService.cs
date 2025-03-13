using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly HttpClient _httpClient;

        public FeatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            await _httpClient.PostAsJsonAsync<CreateFeatureDto>("features",createFeatureDto);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _httpClient.DeleteAsync("features/" + id);
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultFeatureDto>>("features");
            return values;
        }

        public async Task<UpdateFeatureDto> GetByIdFeatureAsync(string id)
        {
            var value = await _httpClient.GetFromJsonAsync<UpdateFeatureDto>("features/" + id);
            return value;
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateFeatureDto>("features" , updateFeatureDto);
        }
    }
}
