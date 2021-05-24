using CarRental.Core.Entities;
using System.Threading.Tasks;

namespace CarRental.Core.Interfaces
{
    public interface IBookingService
    {
        Task<Booking> GetBookingAsync(string bookingNumber);
        Task<Booking> PickUpAsync(Booking booking);
        Task<Booking> ReturnAsync(Booking booking);
    }
}
