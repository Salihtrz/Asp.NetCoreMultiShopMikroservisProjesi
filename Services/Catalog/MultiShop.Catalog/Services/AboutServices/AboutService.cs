using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly IMongoCollection<About> _abouts;
        IMapper _mapper;

        public AboutService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _abouts = database.GetCollection<About>(databaseSettings.AboutCollectionName);
            _mapper = mapper;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            var value = _mapper.Map<About>(createAboutDto);
            await _abouts.InsertOneAsync(value);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _abouts.DeleteOneAsync(x => x.AboutID == id);
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            var values = await _abouts.Find(x =>true).ToListAsync();
            return _mapper.Map<List<ResultAboutDto>>(values);
        }

        public async Task<GetByIdAboutDto> GetByIdAboutAsync(string id)
        {
            var value = await _abouts.Find<About>(x => x.AboutID ==id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdAboutDto>(value);
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var value = _mapper.Map<About>(updateAboutDto);
            await _abouts.FindOneAndReplaceAsync(x => x.AboutID == updateAboutDto.AboutID, value);
        }
    }
}
