using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailsDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productDetail;
        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productDetail = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var value = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _productDetail.InsertOneAsync(value);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetail.DeleteOneAsync(x => x.ProductDetailID == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values = await _productDetail.Find<ProductDetail>(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(values);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var value = await _productDetail.Find<ProductDetail>(x => x.ProductDetailID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(value);
        }

        public async Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string id)
        {
            var value = await _productDetail.Find<ProductDetail>(x => x.ProductID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(value);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var value = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productDetail.FindOneAndReplaceAsync(x => x.ProductDetailID == updateProductDetailDto.ProductDetailID, value);
        }
    }
}
