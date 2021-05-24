using CarRental.Core.Entities;
using CarRental.Core.Interfaces;
using CarRentalAPI.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RentCarController : ControllerBase
    {
        private readonly ILogger<RentCarController> _logger;
        private readonly IBookingService _bookingService;
        private readonly ICarService _carService;

        public RentCarController(ILogger<RentCarController> logger, IBookingService bookingService, ICarService carService)
        {
            _logger = logger;
            this._bookingService = bookingService;
            this._carService = carService;
        }

        [HttpGet("{bookingNumber}")]
        public async Task<ActionResult<Booking>> GetAsync(string bookingNumber)
        {
            var booking = await _bookingService.GetBookingAsync(bookingNumber);
            return Ok(booking);
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> PickupAsync([FromBody] CarBookingDto carBooking)
        {
            var bookingNumber = Guid.NewGuid().ToString();
            var car = await _carService.GetCarAsync(carBooking.CarRegistrationNumber);

            if(car == null)
            {
                return BadRequest("Selected Car doesn't exist");
            }
            var booking = new Booking { 
                BookingNumber = bookingNumber,
                CarRegistrationPlate = car.RegistrationPlate,
                CustomerRegistrationId = carBooking.CustomerId,
                PickupDate = carBooking.PickupDate,
                Car = car
            };

            var saved = await _bookingService.PickUpAsync(booking);
            return Ok(saved);
        }

        [HttpPut]
        public async Task<ActionResult<Booking>> ReturnAsync([FromBody] ReturnCarDto carReturn)
        {
            var booking = await _bookingService.GetBookingAsync(carReturn.BookingNumber);
            booking.ReturnDate = carReturn.ReturnDate;
            booking.TripKm = carReturn.Mileage - booking.Car.Mileage;
            booking.Car.Mileage = carReturn.Mileage;

            var saved = await _bookingService.ReturnAsync(booking);
            return Ok(saved);
        }
    }
}
