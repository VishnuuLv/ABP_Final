using Flight.Services.BookingSchedule.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.BookingSchedule.Repository
{
    public interface IBookingRepository
    {
        Task<IEnumerable<BookingViewDto>> GetBooking();
        Task<IEnumerable<BookingViewDto>> GetBookingByPNR(string pnr);
        Task<IEnumerable<BookingViewDto>> GetBookingByUserId(int userId);
        Task<BookingViewDto> GetBookingByemailId(string emailId);
        Task<BookingDto> CreateUpdateBooking(BookingDto bookingDto);
        Task<bool> DeleteBooking(int bookingId);
        Task<IEnumerable<PassengerViewDto>> GetPassengerlistById(int bookingid);
    }
}
