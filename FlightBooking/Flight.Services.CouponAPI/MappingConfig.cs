using AutoMapper;
using Flight.Services.CouponAPI.Models;
using Flight.Services.CouponAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>().ReverseMap();
                config.CreateMap<CouponViewDto, Coupon>().ReverseMap();

            });

            return mappingConfig;
        }
    }
}
