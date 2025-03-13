using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly IMongoCollection<OfferDiscount> _offerDiscount;
        private readonly IMapper _mapper;

        public OfferDiscountService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _offerDiscount = database.GetCollection<OfferDiscount>(databaseSettings.OfferDiscountCollectionName);
            _mapper = mapper;
        }

        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            var value = _mapper.Map<OfferDiscount>(createOfferDiscountDto);
            await _offerDiscount.InsertOneAsync(value);
        }

        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _offerDiscount.DeleteOneAsync(x => x.OfferDiscountID == id);
        }

        public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
        {
            var values = await _offerDiscount.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultOfferDiscountDto>>(values);
        }

        public async Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
        {
            var value = await _offerDiscount.Find(x => x.OfferDiscountID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdOfferDiscountDto>(value);
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            var value = _mapper.Map<OfferDiscount>(updateOfferDiscountDto);
            await _offerDiscount.FindOneAndReplaceAsync(x => x.OfferDiscountID == updateOfferDiscountDto.OfferDiscountID, value);
        }
    }
}
