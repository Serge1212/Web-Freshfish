using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Worker
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        [Required]
        public string Name { get; set; }
        [BsonElement("Surname")]
        [Required]
        public string Surname { get; set; }
        [BsonElement("Patronymic")]
        [Required]
        public string Patronymic { get; set; }
        [BsonElement("Position")]
        [Required]
        public string Position { get; set; }
        [BsonElement("Salary")]
        [Required]
        public string Salary { get; set; }
        [BsonElement("PhoneNumber")]
        [Required]
        public string PhoneNumber { get; set; }
        [BsonElement("Address")]
        [Required]
        public string Address { get; set; }
        [BsonElement("AdditionInfo")]
        [Required]
        public string AdditionInfo { get; set; }
    }
}
