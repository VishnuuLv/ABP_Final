using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.ManageAPI.Models
{
    public class Airline
    {
        [Key]
        public int flightId { get; set; }
        [Required]
        public string flightName { get; set; }
        public string contactNumber { get; set; }
        public string contactAddress { get; set; }
        public string logoURL { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
        
        public string isActive { get; set; }
    }
}
