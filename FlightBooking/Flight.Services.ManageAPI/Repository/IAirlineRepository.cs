using Flight.Services.ManageAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.ManageAPI.Repository
{
    public interface IAirlineRepository
    {
        Task<IEnumerable<AirlineViewDto>> GetAirlines();
        Task<AirlineViewDto> GetAirlineById(int flightId);
        Task<AirlineDto> CreateUpdateAirline(AirlineDto airlineDto);
        Task<bool> DeleteAirline(int flightId);
    }
}
