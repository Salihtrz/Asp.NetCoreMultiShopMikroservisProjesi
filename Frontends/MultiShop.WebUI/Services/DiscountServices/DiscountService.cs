using Microsoft.AspNetCore.Http.HttpResults;
using MultiShop.DtoLayer.DiscountDtos;
using System.Net;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7071/api/discounts/GetCodeDetailByCodeAsync?code=" + code);
            if(responseMessage.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }
            else
            {
                var values = await responseMessage.Content.ReadFromJsonAsync<GetDiscountCodeDetailByCode>();
                return values;
            }
        }
    }
}
