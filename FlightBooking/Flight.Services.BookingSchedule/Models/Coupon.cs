using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.BookingSchedule.Models
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }

        [Required]
        public string couponCode { get; set; }
        public double discountPercentage { get; set; }
        public int maxAmount { get; set; }
        public string flightId { get; set; }
        public DateTime validityStartDate { get; set; }
        public DateTime validityEndDate { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }

        [DefaultValue('Y')]
        public char IsActive { get; set; }
    }
}
