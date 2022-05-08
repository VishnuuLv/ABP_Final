using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.BookingSchedule.Models.Dto
{
    public class CouponViewDto
    {
        public int couponId { get; set; }
        public string couponCode { get; set; }
        public double discountPercentage { get; set; }
        public int maxAmount { get; set; }
        public string flightId { get; set; }
        public DateTime validityStartDate { get; set; }
        public DateTime validityEndDate { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
        public char isActive { get; set; }
    }
}
