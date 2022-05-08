using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.LoggingApi.Model.Dto
{
    public class LogsDto
    {
        public string log { get; set; }
        public string task { get; set; }
        public string senderAPI { get; set; }
    }
}
