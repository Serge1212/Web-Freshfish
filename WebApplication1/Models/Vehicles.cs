using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Vehicles
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Model")]  
        [Required]
        public string Model { get; set; }
        [BsonElement("Mark")]
        [Required]
        public string Mark { get; set; }
        [BsonElement("ManufactureDate")]
        [Required]
        public string ManufactureDate { get; set; }
        [BsonElement("Mileage")]
        [Required]
        public string Mileage { get; set; }
        [BsonElement("FuelConsumption")]
        [Required]
        public string FuelConsumption { get; set; }
    }
}
