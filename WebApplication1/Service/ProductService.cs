using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> products;

        public ProductService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("FreshFish"));
            IMongoDatabase database = client.GetDatabase("FreshFish");
            products = database.GetCollection<Product>("Products");
        }

        public List<Product> Get()
        {
            return products.Find(product => true).ToList();
        }

        public Product Get(string id)
        {
            return products.Find(product => product.Id == id).FirstOrDefault();
        }

        public Product Create(Product product)
        {
            products.InsertOne(product);
            return product;
        }

        public void Update(string id, Product productIn)
        {
            products.ReplaceOne(product => product.Id == id, productIn);
        }

        public void Remove(Product productIn)
        {
            products.DeleteOne(product => product.Id == productIn.Id);
        }

        public void Remove(string id)
        {
            products.DeleteOne(product => product.Id == id);
        }
    }
}
