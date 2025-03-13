using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly IMongoCollection<SpecialOffer> _specialOffer;
        private readonly IMapper _mapper;

        public SpecialOfferService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _specialOffer = database.GetCollection<SpecialOffer>(databaseSettings.SpecialOfferCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var value = _mapper.Map<SpecialOffer>(createSpecialOfferDto);
            await _specialOffer.InsertOneAsync(value);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _specialOffer.DeleteOneAsync(x => x.SpecialOfferID == id);
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            var values = await _specialOffer.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSpecialOfferDto>>(values);
        }

        public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            var value = await _specialOffer.Find<SpecialOffer>(x => x.SpecialOfferID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSpecialOfferDto>(value);
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var value = _mapper.Map<SpecialOffer>(updateSpecialOfferDto);
            await _specialOffer.FindOneAndReplaceAsync(x => x.SpecialOfferID == updateSpecialOfferDto.SpecialOfferID,value);
        }
    }
}
