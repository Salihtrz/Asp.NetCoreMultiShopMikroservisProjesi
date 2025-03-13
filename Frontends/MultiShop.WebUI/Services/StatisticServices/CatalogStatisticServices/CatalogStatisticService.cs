

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices
{
    public class CatalogStatisticService : ICatalogStatisticService
    {
        private readonly HttpClient _httpClient;

        public CatalogStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<long> GetBrandCount()
        {
            var response = await _httpClient.GetAsync("Statistics/GetBrandCount");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(content);
            return jsonObject["result"]?.Value<long>() ?? 0;
        }

        public async Task<long> GetCategoryCount()
        {
            var response = await _httpClient.GetAsync("Statistics/GetCategoryCount");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(content);
            return jsonObject["result"]?.Value<long>() ?? 0;
        }

        public async Task<string> GetMaxPriceProductName()
        {
            var response = await _httpClient.GetAsync("Statistics/GetMaxPriceProductName");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(content);
            return jsonObject["result"]?.Value<string>() ?? string.Empty;
        }

        public async Task<List<string>> GetMinPriceProductName()
        {
            var response = await _httpClient.GetAsync("Statistics/GetMinPriceProductName");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(content);
            return jsonObject["result"]?.ToObject<List<string>>() ?? new List<string>();
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            var response = await _httpClient.GetAsync("Statistics/GetProductAvgPrice");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(content);
            return jsonObject["result"]?.Value<decimal>() ?? 0;
        }

        public async Task<long> GetProductCount()
        {
            var response = await _httpClient.GetAsync("Statistics/GetProductCount");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(content);
            return jsonObject["result"]?.Value<long>() ?? 0;
        }
    }
}
