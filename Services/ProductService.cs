using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RedHookCraftWebsite.Models;

namespace RedHookCraftWebsite.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> _product;
        private readonly DatabaseConnector _settings;

        public ProductService(IOptions<DatabaseConnector> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _product = database.GetCollection<Product>(_settings.ProductCollectionName);
        }
        public async Task<List<Product>> GetAllAsync()
        {
            return await _product.Find(c => true).ToListAsync();
        }
        public async Task<Product> GetByIdAsync(string id)
        {
            return await _product.Find<Product>(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Product> CreateAsync(Product product)
        {
            await _product.InsertOneAsync(product);
            return product;
        }
        public async Task UpdateAsync(string id, Product product)
        {
            await _product.ReplaceOneAsync(c => c.Id == id, product);
        }
        public async Task DeleteAsync(string id)
        {
            await _product.DeleteOneAsync(c => c.Id == id);
        }
    }
}
