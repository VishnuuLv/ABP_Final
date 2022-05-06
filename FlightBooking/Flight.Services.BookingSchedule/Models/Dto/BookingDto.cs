using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.BookingSchedule.Models.Dto
{
    public class BookingDto
    {
        //public int BookingId { get; set; }
        public int scheduleDetailsId { get; set; }
        public int userId { get; set; }
        public string name { get; set; }
        public string emailId { get; set; }
        public int noOfSeats { get; set; }
        public List<PassengerDto> passenger { get; set; }
        
        public string couponCode { get; set; }
        //public string Gender { get; set; }
        //public int Age { get; set; }
       
        //public int NoOfSeats { get; set; }
        
    }
}
