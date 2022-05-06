using AutoMapper;
using Flight.Services.ManageAPI.DbContexts;
using Flight.Services.ManageAPI.Models;
using Flight.Services.ManageAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.ManageAPI.Repository
{
    public class AirlineRepository : IAirlineRepository
    {

        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public AirlineRepository(ApplicationDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<AirlineDto> CreateUpdateAirline(AirlineDto airlineDto)
        {
            Airline airline = _mapper.Map<AirlineDto, Airline>(airlineDto);
            var CreatedDateTemp= await _db.Flight.Where(u => u.flightId == airline.flightId).Select(u => u.createdDate).SingleOrDefaultAsync();
            if (airline.flightId> 0)
            {
                airline.isActive = "Y";
                airline.updatedDate = DateTime.Now;
                airline.createdDate = CreatedDateTemp;
                _db.Flight.Update(airline);
            }
            else
            {
                airline.isActive = "Y";
                airline.createdDate = DateTime.Now;
                airline.updatedDate = DateTime.Now;
                _db.Flight.Add(airline);
            }
            await _db.SaveChangesAsync();

            return _mapper.Map<Airline, AirlineDto>(airline);
        }

        public async Task<bool> DeleteAirline(int flightId)
        {
            try
            {
                Airline airline = await _db.Flight.FirstOrDefaultAsync(x => x.flightId == flightId);
                if(airline==null)
                {
                    return false;
                }
                else
                {
                    //_db.Flight.Remove(airline);
                    airline.isActive = "N";
                    await _db.SaveChangesAsync();
                    return true;
                }

                

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<AirlineViewDto> GetAirlineById(int flightId)
        {
            Airline airline = await _db.Flight.Where(x => x.flightId == flightId).FirstOrDefaultAsync();
            return _mapper.Map<AirlineViewDto>(airline);
        }

        public async Task<IEnumerable<AirlineViewDto>> GetAirlines()
        {
            List<Airline> airlineList = await _db.Flight.ToListAsync();
            return _mapper.Map<List<AirlineViewDto>>(airlineList);
        }

    }
}
