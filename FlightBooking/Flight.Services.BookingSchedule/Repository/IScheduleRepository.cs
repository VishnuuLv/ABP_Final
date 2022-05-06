using Flight.Services.BookingSchedule.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.BookingSchedule.Repository
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<ScheduleDetailViewDto>> GetSchedule();
        Task<IEnumerable<ScheduleDetailViewDto>> GetAllSchedule();
        Task<ScheduleDetailDto> CreateUpdateSchedule(ScheduleDetailDto scheduleDetailsDto);
        Task<bool> RemoveSchedule(int ScheduleDetailsId);
        Task<IEnumerable<ScheduleDetailViewDto>> GetScheduleByDate(DateTime startDate);
        Task<IEnumerable<ScheduleDetailViewDto>> GetScheduleBySourceDestination(string source, string destination);
        Task<IEnumerable<ScheduleDetailViewDto>> GetScheduleBySDwithDate(string source, string destination, DateTime traveldate);
        Task<ScheduleDetailViewDto> GetScheduleById(int ScheduleDetailsId);
        Task<bool> AddOrder(AirlineViewDto airline);
    }
}
