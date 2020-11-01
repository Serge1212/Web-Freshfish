using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class WorkerService
    {
        private readonly IMongoCollection<Worker> workers;

        public WorkerService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("FreshFish"));
            IMongoDatabase database = client.GetDatabase("FreshFish");
            workers = database.GetCollection<Worker>("Workers");
        }

        public List<Worker> Get()
        {
            return workers.Find(worker => true).ToList();
        }

        public Worker Get(string id)
        {
            return workers.Find(worker => worker.Id == id).FirstOrDefault();
        }

        public Worker Create(Worker worker)
        {
            workers.InsertOne(worker);
            return worker;
        }

        public void Update(string id, Worker workerIn)
        {
            workers.ReplaceOne(worker => worker.Id == id, workerIn);
        }

        public void Remove(Worker workerIn)
        {
            workers.DeleteOne(worker => worker.Id == workerIn.Id);
        }

        public void Remove(string id)
        {
            workers.DeleteOne(worker => worker.Id == id);
        }
    }
}
