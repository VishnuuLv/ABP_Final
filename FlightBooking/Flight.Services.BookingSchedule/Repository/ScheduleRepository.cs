using AutoMapper;
using EFCore.BulkExtensions;
using Flight.Services.BookingSchedule.DbContexts;
using Flight.Services.BookingSchedule.Models;
using Flight.Services.BookingSchedule.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.BookingSchedule.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {

        private readonly ApplicationDbContext _db;
        private IMapper _mapper;


        public ScheduleRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ScheduleDetailDto> CreateUpdateSchedule(ScheduleDetailDto scheduleDetailsDto)
        {
            ScheduleDetail schedule = _mapper.Map<ScheduleDetailDto, ScheduleDetail>(scheduleDetailsDto);
            var CreatedDateTemp = await _db.ScheduleDetails.Where(u => u.scheduleDetailsId == schedule.scheduleDetailsId).Select(u => u.createdDate).SingleOrDefaultAsync();

            if (schedule.scheduleDetailsId > 0)
            {
                schedule.isActive = "Y";
                schedule.updatedDate = DateTime.Now;
                schedule.createdDate = CreatedDateTemp;
                schedule.totalSeats = schedule.economySeats + schedule.businessClassSeats;
                schedule.availableBusinessClassSeats = schedule.businessClassSeats;
                schedule.availableEconomySeats = schedule.economySeats;
                schedule.availableTotalSeats = schedule.economySeats + schedule.businessClassSeats; 
                _db.ScheduleDetails.Update(schedule);
                
            }
            else
            {
                
                if (schedule.scheduledDays == "Daily")
                {
                    List<ScheduleDetail> Sd = new List<ScheduleDetail>();                    
                    for (int i = 0; i <= 60; i++)
                    {
                        Sd.Add(new ScheduleDetail() {
                            flightId=schedule.flightId,
                            flightNumber=schedule.flightNumber,
                            fromPlace=schedule.fromPlace,
                            toPlace=schedule.toPlace,
                            startDate = schedule.startDate.AddDays(i),
                            endDate = schedule.endDate.AddDays(i),
                            scheduledDays=schedule.scheduledDays,
                            instrumentused=schedule.instrumentused,
                            economySeats=schedule.economySeats,
                            businessClassSeats=schedule.businessClassSeats,
                            totalSeats=schedule.economySeats+schedule.businessClassSeats,
                            availableBusinessClassSeats = schedule.businessClassSeats,
                            availableEconomySeats = schedule.economySeats,
                            availableTotalSeats = schedule.economySeats + schedule.businessClassSeats,
                            economyCost=schedule.economyCost,
                            businessClassCost=schedule.businessClassCost,
                            isActive = "Y",
                            createdDate = DateTime.Now,
                            updatedDate = DateTime.Now,
                            meal=schedule.meal,
                            noOfRows=schedule.noOfRows
                        });                        
                    }               
                    await _db.BulkInsertAsync(Sd);                    
                }                
            } 
            await _db.SaveChangesAsync();
            return _mapper.Map<ScheduleDetail, ScheduleDetailDto>(schedule);
        }

        public async Task<IEnumerable<ScheduleDetailViewDto>> GetSchedule()
        {
            
            List<ScheduleDetail> scheduleList = await _db.ScheduleDetails               
                .Where(a=> a.startDate.Date == DateTime.Today.Date && a.startDate.TimeOfDay>DateTime.UtcNow.TimeOfDay)
                .ToListAsync();            
            return _mapper.Map<List<ScheduleDetailViewDto>>(scheduleList);
        }

        public async Task<bool> RemoveSchedule(int ScheduleDetailsId)
        {
            try
            {
                ScheduleDetail schedule = await _db.ScheduleDetails.FirstOrDefaultAsync(x => x.scheduleDetailsId == ScheduleDetailsId);
                if (schedule == null)
                {
                    return false;
                }
                else
                {
                    schedule.isActive = "N";
                    await _db.SaveChangesAsync();
                    return true;
                }



            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<ScheduleDetailViewDto> GetScheduleById(int scheduleDetailsId)
        {
            ScheduleDetail scheduleDetail = await _db.ScheduleDetails.Where(x => x.scheduleDetailsId == scheduleDetailsId).FirstOrDefaultAsync();
            return _mapper.Map<ScheduleDetailViewDto>(scheduleDetail);
        }



        public async Task<IEnumerable<ScheduleDetailViewDto>> GetScheduleByDate(DateTime startDate)
        {

            List<ScheduleDetail> scheduleDetail =
                await _db.ScheduleDetails.Where(x => x.startDate.Date == startDate.Date).ToListAsync();
            return _mapper.Map<List<ScheduleDetailViewDto>>(scheduleDetail);
        }

        public async Task<IEnumerable<ScheduleDetailViewDto>> GetScheduleBySourceDestination(string source, string destination)
        {
            List<ScheduleDetail> scheduleDetail =
               await _db.ScheduleDetails.Where(x => x.fromPlace == source && x.toPlace == destination).ToListAsync();
            return _mapper.Map<List<ScheduleDetailViewDto>>(scheduleDetail);
        }
        public async Task<IEnumerable<ScheduleDetailViewDto>> GetScheduleBySDwithDate(string source, string destination, DateTime traveldate)
        {
            List<ScheduleDetail> scheduleDetail =
               await _db.ScheduleDetails.Where(x => x.fromPlace == source && x.toPlace == destination && x.startDate.Date == traveldate.Date).ToListAsync();
            return _mapper.Map<List<ScheduleDetailViewDto>>(scheduleDetail);
        }

        public async Task<bool> AddOrder(AirlineViewDto airline)
        {
            Airline airdto = _mapper.Map<AirlineViewDto, Airline>(airline);
            _db.Flight.Add(airdto);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ScheduleDetailViewDto>> GetAllSchedule()
        {
            List<ScheduleDetail> scheduleList = await _db.ScheduleDetails.ToListAsync();
            return _mapper.Map<List<ScheduleDetailViewDto>>(scheduleList);
        }
    }
}
