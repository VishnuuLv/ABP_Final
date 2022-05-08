
using Flight.MessageBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.ManageAPI.Models.Dto
{
    public class AirlineViewDto:BaseMessage
    {
        public int flightId { get; set; }        
        public string flightName { get; set; }
        public string contactNumber { get; set; }
        public string contactAddress { get; set; }
        public string logoURL { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }        
        public string isActive { get; set; }
    }
}
