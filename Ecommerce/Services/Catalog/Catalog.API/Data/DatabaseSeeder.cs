using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    public class DatabaseSeeder
    {
        public static async Task SeedAsync(
            IMongoDatabase database,
            string seedDataPath)
        {
            Console.WriteLine("DATABASE SEEDER STARTED");

            var brandsCollection =
                database.GetCollection<ProductBrand>("ProductBrands");

            var typesCollection =
                database.GetCollection<ProductType>("ProductTypes");

            var productsCollection =
                database.GetCollection<Product>("Products");

            if (!await brandsCollection.Find(_ => true).AnyAsync())
            {
                var brandsJson =
                    await File.ReadAllTextAsync(
                        Path.Combine(seedDataPath, "brands.json"));

                var brands =
                    JsonSerializer.Deserialize<List<ProductBrand>>(brandsJson);

                if (brands?.Count > 0)
                    await brandsCollection.InsertManyAsync(brands);
            }

            if (!await typesCollection.Find(_ => true).AnyAsync())
            {
                var typesJson =
                    await File.ReadAllTextAsync(
                        Path.Combine(seedDataPath, "types.json"));

                var types =
                    JsonSerializer.Deserialize<List<ProductType>>(typesJson);

                if (types?.Count > 0)
                    await typesCollection.InsertManyAsync(types);
            }

            if (!await productsCollection.Find(_ => true).AnyAsync())
            {
                var productsJson =
                    await File.ReadAllTextAsync(
                        Path.Combine(seedDataPath, "products.json"));

                var products =
                    JsonSerializer.Deserialize<List<Product>>(productsJson);

                if (products?.Count > 0)
                    await productsCollection.InsertManyAsync(products);
            }
        }
    }
}