using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCategoryDto>("categories", createCategoryDto);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _httpClient.DeleteAsync("categories/" + id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var responseMessage = await _httpClient.GetAsync("categories");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            return values;
        }
        // Bu yorum satırının üst ve altındaki kod bloğu, aynı işlevi yapıyor.
        public async Task<UpdateCategoryDto> GetByIdCategoryAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("categories/" + id);
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateCategoryDto>();
            return value;
        }
        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCategoryDto>("categories",updateCategoryDto);
        }
    }
}
