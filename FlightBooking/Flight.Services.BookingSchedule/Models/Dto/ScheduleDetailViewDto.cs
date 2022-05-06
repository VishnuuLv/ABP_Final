using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.BookingSchedule.Models.Dto
{
    public class ScheduleDetailViewDto
    {
        public int scheduleDetailsId { get; set; }
        public int flightId { get; set; }

       
        public string flightNumber { get; set; }
        public string fromPlace { get; set; }
        public string toPlace { get; set; }
        //public TimeSpan Starttime { get; set; }
        //public TimeSpan Endtime { get; set; }
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime startDate { get; set; }
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime endDate { get; set; }
        public string scheduledDays { get; set; }
        public string instrumentused { get; set; }
        public int economySeats { get; set; }
        public int businessClassSeats { get; set; }
        public int totalSeats { get; set; }
        public int availableEconomySeats { get; set; }
        public int availableBusinessClassSeats { get; set; }
        public int availableTotalSeats { get; set; }
        public double economyCost { get; set; }
        public double businessClassCost { get; set; }
        public int noOfRows { get; set; }
        public string meal { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }

        public string isActive { get; set; }
    }
}
