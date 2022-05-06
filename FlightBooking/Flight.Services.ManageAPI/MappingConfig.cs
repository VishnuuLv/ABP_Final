using AutoMapper;
using Flight.Services.ManageAPI.Models;
using Flight.Services.ManageAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.ManageAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
              {
                  config.CreateMap<AirlineDto, Airline>();
                  config.CreateMap<Airline, AirlineDto>();
                  config.CreateMap<AirlineViewDto, Airline>().ReverseMap();

                  //config.CreateMap<ScheduleHeader, ScheduleHeaderDto>().ReverseMap();
                  //config.CreateMap<ScheduleDetails, ScheduleDetailsDto>().ReverseMap();
              });
            return mappingConfig;
        }
    }
}
