using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.BookingSchedule.Models.Dto
{
    public class BookingViewDto
    {
        public int bookingId { get; set; }
        public string PNR { get; set; }
        public int scheduleDetailsId { get; set; }
        public int userId { get; set; }
        public string name { get; set; }
        public string emailId { get; set; }
        public int noOfSeats { get; set; }
        public List<PassengerDto> passenger { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }

        public string isActive { get; set; }
        public string couponCode { get; set; }
        
        public string source { get; set; }
        public string destination { get; set; }
        public DateTime departureDate { get; set; }
        public DateTime arrivalDate { get; set; }
        public double originalTicketCost { get; set; }
        public double finalticketCost { get; set; }
    }
}
