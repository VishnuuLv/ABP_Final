using AutoMapper;
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
    public class BookingRepository : IBookingRepository
    {

        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public BookingRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<BookingDto> CreateUpdateBooking(BookingDto bookingDto)
        {
            Booking booking = _mapper.Map<BookingDto, Booking>(bookingDto);
            int businessCount = 0;
            int economyCount = 0;
            double discountCost = 0;
            var CreatedDateTemp = await _db.Bookings.Where(u => u.bookingId == booking.bookingId).Select(u => u.createdDate).SingleOrDefaultAsync();
            if (booking.bookingId > 0)
            {
                booking.isActive = "Y";
                booking.updatedDate = DateTime.Now;
                booking.createdDate = CreatedDateTemp;
                _db.Bookings.Update(booking);
            }
            else
            {
                ScheduleDetail scheduleDetail = await _db.ScheduleDetails.FirstOrDefaultAsync(x => x.scheduleDetailsId == booking.scheduleDetailsId);
                //double cost = 0;
                if (scheduleDetail.availableTotalSeats>booking.noOfSeats)
                {
                    booking.isActive = "Y";
                    booking.createdDate = DateTime.Now;
                    booking.updatedDate = DateTime.Now;
                    booking.source = scheduleDetail.fromPlace;
                    booking.destination = scheduleDetail.toPlace;
                    booking.departureDate = scheduleDetail.startDate;
                    booking.arrivalDate = scheduleDetail.endDate;
                    _db.Bookings.Add(booking);
                    //var bookingId = await _db.Bookings.Where(u => u.CreatedDate == booking.CreatedDate).Select(u => u.BookingId).SingleOrDefaultAsync();
                    if (booking.passenger.Count > 0)
                    {
                        for (int i = 0; i < booking.passenger.Count; i++)
                        {
                            if (booking.passenger[i].typeOfSeats == "B")
                            {
                                businessCount++;
                                booking.originalTicketCost = booking.originalTicketCost + scheduleDetail.businessClassCost;
                            }
                            else if (booking.passenger[i].typeOfSeats == "E")
                            {
                                economyCount++;
                                booking.originalTicketCost = booking.originalTicketCost + scheduleDetail.economyCost;
                            }
                        }
                        booking.PNR = "ABP"+booking.createdDate.Day+booking.createdDate.Hour+booking.createdDate.Second+booking.createdDate.Minute+booking.userId+booking.departureDate.Day;
                        await UpdateBookingDetails(booking.scheduleDetailsId, booking.noOfSeats, businessCount, economyCount);
                    }
                    if(booking.couponCode!=null)
                    {
                        Coupon coupon= await _db.coupons.FirstOrDefaultAsync(x => x.couponCode.ToUpper() == booking.couponCode.ToUpper());
                        if(coupon!=null)
                        {
                            // booking.finalticketCost = booking.originalTicketCost - (booking.originalTicketCost * (coupon.discountPercentage / 100));
                            if(coupon.validityEndDate>=DateTime.Today && coupon.validityStartDate <= DateTime.Today)
                            {
                                discountCost = booking.originalTicketCost * (coupon.discountPercentage / 100);
                                if(coupon.flightId.ToUpper() == "ALL")
                                {
                                    if(discountCost>coupon.maxAmount)
                                    {
                                        booking.finalticketCost = booking.originalTicketCost - coupon.maxAmount;
                                    }
                                    else
                                    {
                                        booking.finalticketCost = booking.originalTicketCost - discountCost;
                                    }
                                    
                                }
                                else if(Convert.ToInt32(coupon.flightId)== scheduleDetail.flightId)
                                {
                                    if (discountCost > coupon.maxAmount)
                                    {
                                        booking.finalticketCost = booking.originalTicketCost - coupon.maxAmount;
                                    }
                                    else
                                    {
                                        booking.finalticketCost = booking.originalTicketCost - discountCost;
                                    }
                                }
                                else
                                {
                                    booking.finalticketCost = booking.originalTicketCost;
                                }
                            }
                            else
                            {
                                booking.finalticketCost = booking.originalTicketCost;
                            }
                        }
                        else
                        {
                            booking.finalticketCost = booking.originalTicketCost;
                        }
                    }
                    else
                    {
                        booking.finalticketCost = booking.originalTicketCost;
                    }
                }
                else
                {
                    booking.PNR = "Null";
                }


            }
            await _db.SaveChangesAsync();        
            

            return _mapper.Map<Booking, BookingDto>(booking);
        }

        public async Task<bool> UpdateBookingDetails(int scheduleId,int noOfSeats,int countOfBc,int countOfEc)
        {
            ScheduleDetail scheduleDetail = await _db.ScheduleDetails.FirstOrDefaultAsync(x => x.scheduleDetailsId == scheduleId);
            if (scheduleDetail == null)
            {
                return false;
            }
            try
            {
                scheduleDetail.availableTotalSeats = scheduleDetail.availableTotalSeats - noOfSeats;
                scheduleDetail.availableBusinessClassSeats = scheduleDetail.availableBusinessClassSeats - countOfBc;
                scheduleDetail.availableEconomySeats = scheduleDetail.availableEconomySeats - countOfEc;     
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteBooking(int bookingId)
        {
            try
            {
                Booking booking = await _db.Bookings.FirstOrDefaultAsync(x => x.bookingId == bookingId);
                if (booking == null)
                {
                    return false;
                }

                //_db.Bookings.Remove(booking);
                booking.isActive = "N";
                await _db.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<BookingViewDto>> GetBookingByPNR(string pnr)
        {
            List<Booking> store = await _db.Bookings
                            .Where(s => s.PNR == pnr)
                            .Include(s => s.passenger)
                            .ToListAsync();
            return _mapper.Map<List<BookingViewDto>>(store);
        }


        public async Task<IEnumerable<BookingViewDto>> GetBookingByUserId(int userId)
        {
            //List<Booking> booking = await _db.Bookings.Where(x => x.UserId == userId).ToListAsync();
            List<Booking> store = await _db.Bookings
                           .Where(s => s.userId == userId)
                           .Include(s => s.passenger)
                           .ToListAsync();
            return _mapper.Map<List<BookingViewDto>>(store);
        }


        public async Task<IEnumerable<BookingViewDto>> GetBooking()
        {
            List<Booking> BookingList = await _db.Bookings.ToListAsync();
            return _mapper.Map<List<BookingViewDto>>(BookingList);
        }

        public async Task<BookingViewDto> GetBookingByemailId(string emailId)
        {
            Booking booking = await _db.Bookings.Where(x => x.emailId == emailId).FirstOrDefaultAsync();
            return _mapper.Map<BookingViewDto>(booking);
        }

        public async Task<IEnumerable<PassengerViewDto>> GetPassengerlistById(int bookingid)
        {
            List<Passenger> store = await _db.Passengers
                           .Where(s => s.bookingId == bookingid)
                           //.Include(s => s.passenger)
                           .ToListAsync();
            return _mapper.Map<List<PassengerViewDto>>(store);
        }
    }
}
