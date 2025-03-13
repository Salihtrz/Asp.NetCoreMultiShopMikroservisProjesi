using MultiShop.DtoLayer.CatalogDtos.ProductDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDto>("products",createProductDto);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _httpClient.DeleteAsync("products/" + id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultProductDto>>("products");
            return values;
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var value = await _httpClient.GetFromJsonAsync<GetByIdProductDto>("products/" + id);
            return value;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultProductWithCategoryDto>>("products/ProductListWithCategory");
            return values;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultProductWithCategoryDto>>("products/ProductListWithCategoryByCategoryId/" + id);
            return values;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDto>("products", updateProductDto);
        }
    }
}
