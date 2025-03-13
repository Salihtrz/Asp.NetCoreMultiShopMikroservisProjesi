using MultiShop.DtoLayer.CatalogDtos.ContactDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            await _httpClient.PostAsJsonAsync<CreateContactDto>("contacts", createContactDto);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _httpClient.DeleteAsync("contacts/" + id);
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultContactDto>>("contacts");
            return values;
        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            var value = await _httpClient.GetFromJsonAsync<GetByIdContactDto>("contacts/" + id);
            return value;
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateContactDto>("contacts", updateContactDto);
        }
    }
}
