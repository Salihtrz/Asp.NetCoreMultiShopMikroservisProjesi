using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly IMongoCollection<Brand> _brands;
        IMapper _mapper;

        public BrandService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _brands = database.GetCollection<Brand>(databaseSettings.BrandCollectionName);
            _mapper = mapper;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            var value = _mapper.Map<Brand>(createBrandDto);
            await _brands.InsertOneAsync(value);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _brands.DeleteOneAsync(x => x.BrandID == id);
        }

        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {
            var values = await _brands.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultBrandDto>>(values);
        }

        public async Task<GetByIdBrandDto> GetByIdBrandAsync(string id)
        {
            var value = await _brands.Find<Brand>(x => x.BrandID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdBrandDto>(value);
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            var value = _mapper.Map<Brand>(updateBrandDto);
            await _brands.FindOneAndReplaceAsync(x => x.BrandID == updateBrandDto.BrandID, value);
        }
    }
}
