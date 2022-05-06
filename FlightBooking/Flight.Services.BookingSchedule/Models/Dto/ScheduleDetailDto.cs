using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.BookingSchedule.Models.Dto
{
    public class ScheduleDetailDto
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
        //public int totalSeats { get; set; }
        public double economyCost { get; set; }
        public double businessClassCost { get; set; }
        public int noOfRows { get; set; }
        public string meal { get; set; }
        
    }
}
