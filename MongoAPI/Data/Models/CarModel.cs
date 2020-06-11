using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace MongoAPI.Data.Models
{
    public class CarModel
    {
        [BsonId]
        public string Registration { get; set; }

        public string Model { get; set; }

        public string Colour { get; set; }

        public string Make_Id { get; set; }

        public List<TyreModel> Tyres { get; set; }
    }
}