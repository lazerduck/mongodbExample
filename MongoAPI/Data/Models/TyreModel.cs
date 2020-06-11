using System.Collections.Generic;

namespace MongoAPI.Data.Models
{
    public class TyreModel
    {
        public string BrandName { get; set; }

        public int Wear { get; set; }

        public List<BoltsModel> Bolts { get; set; }
    }
}