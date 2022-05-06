using AutoMapper;
using Flight.Services.UserManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.UserManagement
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<UserDto, User>().ReverseMap();
                
            });
            return mappingConfig;
        }
    }
}
