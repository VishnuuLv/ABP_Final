using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.BookingSchedule.Models.Dto
{
    public class PassengerViewDto
    {
        public int PassengerId { get; set; }
        public int BookingId { get; set; }

        public string passengerName { get; set; }
        public string passengerGender { get; set; }
        public int passengerAge { get; set; }
        public string typeOfSeats { get; set; }
        public string optForMeal { get; set; }
    }
}
