using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly HttpClient _httpClient;

        public SpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _httpClient.PostAsJsonAsync<CreateSpecialOfferDto>("specialoffers", createSpecialOfferDto);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _httpClient.DeleteAsync("specialoffers/" + id);
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultSpecialOfferDto>>("specialoffers");
            return values;
        }

        public async Task<UpdateSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            var value = await _httpClient.GetFromJsonAsync<UpdateSpecialOfferDto>("specialoffers/" + id);
            return value;
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateSpecialOfferDto>("specialoffers", updateSpecialOfferDto);
        }
    }
}
