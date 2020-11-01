using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class VehiclesService
    {
        private readonly IMongoCollection<Vehicles> vehicles;

        public VehiclesService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("FreshFish"));
            IMongoDatabase database = client.GetDatabase("FreshFish");
            vehicles = database.GetCollection<Vehicles>("Vehicles");
        }

        public List<Vehicles> Get()
        {
            return vehicles.Find(vehicles => true).ToList();
        }

        public Vehicles Get(string id)
        {
            return vehicles.Find(vehicles => vehicles.Id == id).FirstOrDefault();
        }

        public Vehicles Create(Vehicles vehicles)
        {
            this.vehicles.InsertOne(vehicles);
            return vehicles;
        }

        public void Update(string id, Vehicles vehiclesIn)
        {
            vehicles.ReplaceOne(vehicles => vehicles.Id == id, vehiclesIn);
        }

        public void Remove(Vehicles vehiclesIn)
        {
            vehicles.DeleteOne(vehicles => vehicles.Id == vehiclesIn.Id);
        }

        public void Remove(string id)
        {
            vehicles.DeleteOne(vehicles => vehicles.Id == id);
        }
    }
}
