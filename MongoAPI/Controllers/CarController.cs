using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoAPI.Data;
using MongoAPI.Data.Models;

namespace MongoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController 
    {
        private readonly CarsRepository _repo;

        public CarController(CarsRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{reg}")]
        public async Task<CarModel> GetCar(string reg)
        {
            return await _repo.GetCar(reg);
        }

        [HttpPost]
        public async Task<string> AddCar([FromBody]CarModel car)
        {
            await _repo.AddCar(car);
            return car.Registration;
        }
    }
}