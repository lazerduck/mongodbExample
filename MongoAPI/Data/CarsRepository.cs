using System.Threading.Tasks;
using MongoAPI.Data.Models;
using MongoDB.Driver;

namespace MongoAPI.Data
{
    public class CarsRepository
    {
        private readonly IMongoCollection<CarModel> _carStore;
        private readonly IMongoCollection<CarMakeModel> _carMakeStore;

        public CarsRepository(MongoConfig config)
        {

            var client = new MongoClient(config.ConnectionUrl);
            var database = client.GetDatabase(config.DatabaseName);

            _carStore = database.GetCollection<CarModel>("Cars");
            _carMakeStore = database.GetCollection<CarMakeModel>("CarMakes");
        }

        public async Task<CarModel> GetCar(string reg)
        {
            return (await _carStore.FindAsync(car => car.Registration == reg)).FirstOrDefault();
        }

        public async Task AddCar(CarModel car)
        {
            if((await GetCarMake(car.Make_Id)) == null)
            {
                throw new System.Exception($"Unable to find make {car.Make_Id}");
            }

            await _carStore.InsertOneAsync(car);

            var update = Builders<CarMakeModel>.Update.Inc(nameof(CarMakeModel.CarsSold), 1);
            await _carMakeStore.FindOneAndUpdateAsync(make => make.CarMake == car.Make_Id, update);
        }

        public async Task<CarMakeModel> GetCarMake(string carMakeName)
        {
            return (await _carMakeStore.FindAsync(carMake => carMake.CarMake == carMakeName)).FirstOrDefault();
        }

        public async Task AddCar(CarMakeModel carMake)
        {
            await _carMakeStore.InsertOneAsync(carMake);
        }
    }
}