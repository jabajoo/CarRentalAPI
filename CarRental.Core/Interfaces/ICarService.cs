using CarRental.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRental.Core.Interfaces
{
    public interface ICarService
    {
        IEnumerable<Car> GetCarsAsync();
        Task<Car> GetCarAsync(string registrationNumber);
        Task<Car> AddCarAsync(Car car);
        Task<Category> AddCarCategorynAsync(Category category);
    }
}
