using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _product;
        private readonly IMongoCollection<Category> _categories;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _product = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _categories = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _product.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _product.DeleteOneAsync(x => x.ProductID == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _product.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var value = await _product.Find<Product>(x => x.ProductID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(value);

        }

        public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var values = await _product.Find(x => true).ToListAsync();
            foreach(var item in values)
            {
                item.Category = await _categories.Find<Category>(x => x.CategoryID == item.CategoryID).FirstAsync();

            }
            return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);
        }

        public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string id)
        {
            var values = await _product.Find(x => x.CategoryID == id).ToListAsync();
            foreach (var item in values)
            {
                item.Category = await _categories.Find<Category>(x => x.CategoryID == item.CategoryID).FirstAsync();

            }
            return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            await _product.FindOneAndReplaceAsync(x => x.ProductID == updateProductDto.ProductID, value);
        }
    }
}
