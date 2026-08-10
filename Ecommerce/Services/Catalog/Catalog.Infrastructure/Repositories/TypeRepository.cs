using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        private readonly IMongoCollection<ProductType> _types;
        public TypeRepository(IConfiguration config) 
        {
            var client = new MongoClient(config["DatabaseSettings:ConnectionString"]);
            var db = client.GetDatabase(config["DatabaseSettings:DatabaseName"]);
            _types = db.GetCollection<ProductType>(config["DatabaseSettings:TypeCollectionName"]);
        }
        public async Task<IEnumerable<ProductType>> GetAllProductTypes()
        {
            return await _types.Find(_ => true).ToListAsync();
        }

        public async Task<ProductType> GetProductTypeById(string id)
        {
            return await _types.Find(t => t.Id == id).FirstOrDefaultAsync();
        }
    }
}
