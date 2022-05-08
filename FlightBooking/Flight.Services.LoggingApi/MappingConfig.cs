using AutoMapper;
using Flight.Services.LoggingApi.Model;
using Flight.Services.LoggingApi.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.LoggingApi
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<LogsDto, Logs>().ReverseMap();
                //config.CreateMap<AirlineViewDto, Airline>().ReverseMap();

            });

            return mappingConfig;
        }
    }
}
