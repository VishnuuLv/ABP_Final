using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.BookingSchedule.Models.Dto
{
    public class AirlineDto
    {
        public int flightId { get; set; }
        public string flightName { get; set; }
        public string contactNumber { get; set; }
        public string contactAddress { get; set; }
        public string logoURL { get; set; }
    }
}
