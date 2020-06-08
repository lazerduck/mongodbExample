using System;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoAPI.Data.Models
{

    public class CarMakeModel
    {
        [BsonId]
        public string CarMake { get; set; }

        public DateTime DateFounded { get; set; }

        public int CarsSold { get; set; }
    }
}