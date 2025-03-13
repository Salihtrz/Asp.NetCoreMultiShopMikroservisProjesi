using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _features;
        private readonly IMapper _mapper;

        public FeatureService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _features = database.GetCollection<Feature>(databaseSettings.FeatureCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            var value = _mapper.Map<Feature>(createFeatureDto);
            await _features.InsertOneAsync(value);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _features.DeleteOneAsync(x => x.FeatureID == id);
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            var values = await _features.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureDto>>(values);
        }

        public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id)
        {
            var value = await _features.Find<Feature>(x => x.FeatureID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdFeatureDto>(value);
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            var value = _mapper.Map<Feature>(updateFeatureDto);
            await _features.FindOneAndReplaceAsync(x => x.FeatureID == updateFeatureDto.FeatureID, value);
        }
    }
}
