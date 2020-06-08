using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoAPI.Data;
using MongoAPI.Data.Models;

namespace MongoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarMakeController 
    {
        private readonly CarsRepository _repo;

        public CarMakeController(CarsRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{make}")]
        public async Task<CarMakeModel> GetCarMake(string make)
        {
            return await _repo.GetCarMake(make);
        }

        [HttpPost]
        public async Task<string> AddCarMake([FromBody]CarMakeModel carMake)
        {
            await _repo.AddCar(carMake);
            return carMake.CarMake;
        }
    }
}