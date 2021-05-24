using CarRental.Core.Entities;
using CarRental.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRentalAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        private readonly ICarService _carService;
        public CarController(ILogger<CarController> logger, ICarService carService)
        {
            _logger = logger;
            this._carService = carService;
        }
        // GET: api/<CarController>
        [HttpGet]
        public IEnumerable<Car> GetAll()
        {
            return  _carService.GetCarsAsync();
        }

        // GET api/<CarController>/5
        [HttpGet("{registrationNumber}")]
        public async Task<Car> Get(string registrationNumber)
        {
            return await _carService.GetCarAsync(registrationNumber);
        }

        // POST api/<CarController>
        [HttpPost]
        public void Post([FromBody] Car car)
        {
            _carService.AddCarAsync(car);
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
