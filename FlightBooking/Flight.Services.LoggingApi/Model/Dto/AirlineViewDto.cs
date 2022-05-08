using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.LoggingApi.Model.Dto
{
    public class AirlineViewDto
    {
        public int FlightId { get; set; }

        public string FlightName { get; set; }
        public string ContactNumber { get; set; }
        public string ContactAddress { get; set; }
        public string LogoURL { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public char IsActive { get; set; }
    }
}
