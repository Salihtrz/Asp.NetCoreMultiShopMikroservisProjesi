using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;

namespace MultiShop.WebUI.Services.CatalogServices.SliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly HttpClient _httpClient;

        public FeatureSliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _httpClient.PostAsJsonAsync<CreateFeatureSliderDto>("featuresliders",createFeatureSliderDto);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _httpClient.DeleteAsync("featuresliders/" + id);
        }

        public Task FeatureSliderChangeStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }

        public Task FeatureSliderChangeStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultFeatureSliderDto>>("featuresliders");
            return values;
        }

        public async Task<UpdateFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            var value = await _httpClient.GetFromJsonAsync<UpdateFeatureSliderDto>("featuresliders/" + id);
            return value;
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateFeatureSliderDto>("featuresliders", updateFeatureSliderDto);
        }
    }
}
