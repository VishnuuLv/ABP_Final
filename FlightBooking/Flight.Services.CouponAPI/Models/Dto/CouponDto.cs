using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.CouponAPI.Models.Dto
{
    public class CouponDto
    {
        
        public int couponId { get; set; }        
        public string couponCode { get; set; }
        public double discountPercentage { get; set; }
        public int maxAmount { get; set; }
        public string flightId { get; set; }
        public DateTime validityStartDate { get; set; }
        public DateTime validityEndDate { get; set; }
       

    }
}
