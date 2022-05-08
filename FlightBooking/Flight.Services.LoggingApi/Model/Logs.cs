using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.LoggingApi.Model
{
    public class Logs
    {
        [Key]
        public int id { get; set; }
        public string log { get; set; }
        public string task { get; set; }
        public string senderAPI { get; set; }
        public DateTime createdDate { get; set; }
    }
}
