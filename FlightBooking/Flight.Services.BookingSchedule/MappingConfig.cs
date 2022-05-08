using AutoMapper;
using Flight.Services.BookingSchedule.Models;
using Flight.Services.BookingSchedule.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.BookingSchedule
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {


                config.CreateMap<Booking, BookingDto>().ReverseMap();
                config.CreateMap<Booking, BookingViewDto>().ReverseMap();
                config.CreateMap<Passenger, PassengerDto>().ReverseMap();
                config.CreateMap<AirlineDto, Airline>().ReverseMap();
                //config.CreateMap<ScheduleHeader, ScheduleHeaderDto>().ReverseMap();
                config.CreateMap<ScheduleDetail, ScheduleDetailDto>().ReverseMap();
                config.CreateMap<ScheduleDetail, ScheduleDetailViewDto>().ReverseMap();
                config.CreateMap<AirlineViewDto, Airline>().ReverseMap();
                config.CreateMap<PassengerViewDto, Passenger>().ReverseMap();
                config.CreateMap<Coupon, CouponViewDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}

