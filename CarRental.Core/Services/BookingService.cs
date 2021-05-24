using CarRental.Core.Entities;
using CarRental.Core.Extenssions;
using CarRental.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Core.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRepository<Booking> _bookingRepository;
        private readonly IRepository<Car> _carRepository;
        
        public BookingService(IRepository<Booking> bookingRepository, IRepository<Car> carRepository)
        {
            _bookingRepository = bookingRepository;
            _carRepository = carRepository;
        }
        public async Task<Booking> PickUpAsync(Booking booking)
        {
            var carInRent = _bookingRepository.Where(b=>b.CarRegistrationPlate == booking.CarRegistrationPlate && b.ReturnDate > booking.PickupDate ).FirstOrDefault();
            
            if(carInRent != null)
            {
                throw new Exception(string.Format("Car already reserved for the date", booking.CarRegistrationPlate));
            }
            else
            {
                return await _bookingRepository.AddAsync(booking);
            }
        }

        
        public async Task<Booking> ReturnAsync(Booking booking)
        {
            var bookingDb = _bookingRepository.Where(b => b.BookingNumber == booking.BookingNumber).FirstOrDefault();

            if (bookingDb == null)
            {
                throw new Exception(string.Format("booking number {0} not found", booking.BookingNumber));
            }
            else if (!booking.ReturnDate.HasValue)
            {
                throw new Exception(string.Format("Return Date for booking {0} is not set", booking.BookingNumber));
            }
            else
            {
                var car = _carRepository.Where(c => c.RegistrationPlate == booking.CarRegistrationPlate).FirstOrDefault();
                var days = (booking.ReturnDate - booking.PickupDate).Value.Days;
                var km = booking.TripKm;
                booking.Price = car.Calculate(days, km);
                return await _bookingRepository.UpdateAsync(booking);
            }
        }

        public async Task<Booking> GetBookingAsync(string bookingNumber)
        {
            var booking = await _bookingRepository.Where(b => b.BookingNumber == bookingNumber).FirstOrDefaultAsync();
            return booking;
        }

    }
}
