using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Contact> _contact;
        private readonly IMapper _mapper;

        public ContactService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _contact = database.GetCollection<Contact>(databaseSettings.ContactCollectionName);
            _mapper = mapper;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            var value = _mapper.Map<Contact>(createContactDto);
            await _contact.InsertOneAsync(value);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _contact.DeleteOneAsync(x => x.ContactID == id);
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var values = await _contact.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultContactDto>>(values);
        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            var value = await _contact.Find<Contact>(x => x.ContactID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdContactDto>(value);
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            var value = _mapper.Map<Contact>(updateContactDto);
            await _contact.FindOneAndReplaceAsync(x => x.ContactID == updateContactDto.ContactID, value);
        }
    }
}
