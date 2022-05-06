using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.BookingSchedule.Models
{
    public class Booking
    {
        [Key]
        public int bookingId { get; set; }
        public string PNR { get; set; }
        public int scheduleDetailsId { get; set; }        
        //public virtual List<ScheduleDetail> scheduleDetails { get; set; }
        public int userId { get; set; }
        [Required]
        public string name { get; set; }
        public string emailId { get; set; }
        public int noOfSeats { get; set; }
        public List<Passenger> passenger { get; set; }
        //public string Gender { get; set; }
        //public int Age { get; set; }           
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
        [DefaultValue("Y")]
        public string isActive { get; set; }
        public string source { get; set; }
        public string destination { get; set; }
        public DateTime departureDate { get; set; }
        public DateTime arrivalDate { get; set; }

        #nullable enable
        public string? couponCode { get; set; }
        public double originalTicketCost { get; set; }
        public double finalticketCost { get; set; }

    }
}
