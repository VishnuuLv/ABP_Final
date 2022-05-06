using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.BookingSchedule.Models
{
    public class Passenger
    {
        [Key]
        public int passengerId { get; set; }
        public int bookingId { get; set; }
        public string passengerName { get; set; }
        public string passengerGender { get; set; }
        public int passengerAge { get; set; }
        public string typeOfSeats { get; set; }
        public string optForMeal { get; set; }
    }
}
