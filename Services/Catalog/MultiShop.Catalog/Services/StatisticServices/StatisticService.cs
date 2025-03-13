using MongoDB.Bson;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Brand> _brandCollection;

        public StatisticService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _brandCollection = database.GetCollection<Brand>(databaseSettings.BrandCollectionName);
        }

        public async Task<long> GetBrandCount()
        {
            var value = _brandCollection.CountDocuments(FilterDefinition<Brand>.Empty);
            return value;
        }

        public async Task<long> GetCategoryCount()
        {
            return _categoryCollection.CountDocuments(FilterDefinition<Category>.Empty);
        }

        public async Task<string> GetMaxPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Descending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y => y.ProductName).Exclude("ProductID");
            var product = _productCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefault();
            return product.GetValue("ProductName").AsString;
        }

        public async Task<List<string>> GetMinPriceProductName()
        {
            var products = _productCollection.Find(FilterDefinition<Product>.Empty).ToList();
            var minPrice = products.Min(x => x.ProductPrice);
            var minPriceName = products.Where(x => x.ProductPrice == minPrice).Select(y => y.ProductName).ToList();
            return minPriceName;
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            var products = _productCollection.Find(FilterDefinition<Product>.Empty).ToList();
            var prices = products.Select(x => x.ProductPrice).Where(price => price > 0);
            if (prices.Any())
            {
                return prices.Average();
            }
            else
            {
                return 0;
            }
        }

        public async Task<long> GetProductCount()
        {
            return _productCollection.CountDocuments(FilterDefinition<Product>.Empty);
        }
    }
}
