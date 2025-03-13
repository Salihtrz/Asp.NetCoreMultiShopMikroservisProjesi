using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;

namespace MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly HttpClient _httpClient;

        public OfferDiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _httpClient.PostAsJsonAsync<CreateOfferDiscountDto>("offerdiscounts", createOfferDiscountDto);
        }

        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _httpClient.DeleteAsync("offerdiscounts/" + id);
        }

        public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultOfferDiscountDto>>("offerdiscounts");
            return values;
        }

        public async Task<UpdateOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
        {
            var value = await _httpClient.GetFromJsonAsync<UpdateOfferDiscountDto>("offerdiscounts/" + id);
            return value;
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateOfferDiscountDto>("offerdiscounts", updateOfferDiscountDto);
        }
    }
}
