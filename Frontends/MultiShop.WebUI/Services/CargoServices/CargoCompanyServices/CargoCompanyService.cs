using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;

namespace MultiShop.WebUI.Services.CargoCompanyServices.CargoCompanyServices
{
    public class CargoCompanyService : ICargoCompanyService
    {
        private readonly HttpClient _httpClient;

        public CargoCompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCargoCompanyDto>("cargocompanies", createCargoCompanyDto);
        }

        public async Task DeleteCargoCompanyAsync(int id)
        {
            await _httpClient.DeleteAsync("cargocompanies/" + id);
        }

        public async Task<List<ResultCargoCompanyDto>> GetAllCargoCompanyAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultCargoCompanyDto>>("cargocompanies");
            return values;
        }

        public async Task<UpdateCargoCompanyDto> GetByIdCargoCompanyAsync(int id)
        {
            var value = await _httpClient.GetFromJsonAsync<UpdateCargoCompanyDto>("cargocompanies/" + id);
            return value;
        }

        public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCargoCompanyDto>("cargocompanies", updateCargoCompanyDto);
        }
    }
}
