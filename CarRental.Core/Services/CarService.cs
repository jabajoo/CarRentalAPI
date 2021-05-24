using CarRental.Core.Entities;
using CarRental.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Core.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car> _carRepository;
        private readonly IRepository<Category> _categoryRepository;

        public CarService(IRepository<Car> carRepository, IRepository<Category> categoryRepository)
        {
            this._carRepository = carRepository;
            this._categoryRepository = categoryRepository;
        }
        public async Task<Car> AddCarAsync(Car car)
        {
            var categoryInDb = await _carRepository.Where(c => c.Category.CategoryName == car.Category.CategoryName).Select(c=>c.Category).FirstOrDefaultAsync();
                
            if(categoryInDb == null)
            {
                await AddCarCategorynAsync(car.Category);
            }
            return await _carRepository.AddAsync(car);
            
        }

        public async Task<Category> AddCarCategorynAsync(Category category)
        {
            return await _categoryRepository.AddAsync(category);
        }

        public async Task<Car> GetCarAsync(string registrationNumber)
        {
            var car = await _carRepository.Where(c => c.RegistrationPlate == registrationNumber).FirstOrDefaultAsync();
            return car;
        }

        public  IEnumerable<Car> GetCarsAsync()
        {
            return  _carRepository.All().ToList();
        }
    }
}
