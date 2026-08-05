using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        public BrandRepository(IConfiguration config)
        {
            var client = new MongoClient(config["DatabaseSettings:ConnectionString"]);
        }
        public Task<IEnumerable<ProductBrand>> GetAllBrands()
        {
            throw new NotImplementedException();
        }

        public Task<ProductBrand> GetBrandById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
