using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productImage;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productImage = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(createProductImageDto);
            await _productImage.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productImage.DeleteOneAsync(x => x.ProductImageID  == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _productImage.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var value = await _productImage.Find<ProductImage>(x => x.ProductImageID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(value);
        }

        public async Task<GetByIdProductImageDto> GetByProductIdProductImageAsync(string id)
        {
            var values = await _productImage.Find(x => x.ProductID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(values);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(updateProductImageDto);
            await _productImage.FindOneAndReplaceAsync(x => x.ProductImageID == updateProductImageDto.ProductImageID, value);
        }
    }
}
