using Flight.Services.BookingSchedule.Models.Dto;
using Flight.Services.BookingSchedule.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.BookingSchedule.Controllers
{
    [Route("api/Booking")]
    public class BookingController : Controller
    {
        private readonly IBookingRepository _bookingRepository;
        protected ResponseDto _response;

        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<BookingViewDto> bookingDtos = await _bookingRepository.GetBooking();
                _response.Result = bookingDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return _response;
        }

        [HttpGet]
        [Route("GetbyBookingId/{pnr}")]
        public async Task<object> GetBookingByPNR(string pnr)
        {
            try
            {
                BookingViewDto bookingDtos = await _bookingRepository.GetBookingByPNR(pnr);
                _response.Result = bookingDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return _response;
        }

        [HttpGet]
        [Route("GetByUserId/{userId}")]
        public async Task<object> GetByUserId(int userId)
        {
            try
            {
                IEnumerable<BookingViewDto> bookingDtos = await _bookingRepository.GetBookingByUserId(userId);
                _response.Result = bookingDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return _response;
        }

        [HttpGet]
        [Route("GetPassenger/{bookingid}")]
        public async Task<object> GetPassenger(int bookingid)
        {
            try
            {
                IEnumerable<PassengerViewDto> bookingDtos = await _bookingRepository.GetPassengerlistById(bookingid);
                _response.Result = bookingDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return _response;
        }


        [HttpGet]
        [Route("GetByEmailId/{emailId}")]
        public async Task<object> GetByEmailId(string emailId)
        {
            try
            {
                BookingViewDto bookingDtos = await _bookingRepository.GetBookingByemailId(emailId);
                _response.Result = bookingDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return _response;
        }
        [HttpPost]

        public async Task<object> Post([FromBody] BookingDto bookingDto)
        {
            try
            {
                BookingDto model = await _bookingRepository.CreateUpdateBooking(bookingDto);
                _response.Result = model;
                
                

            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpPut]

        public async Task<object> Put([FromBody] BookingDto bookingDto)
        {
            try
            {
                BookingDto model = await _bookingRepository.CreateUpdateBooking(bookingDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete]
        [Route("{bookingId}")]
        public async Task<object> Post(int bookingId)
        {
            try
            {
                bool isSuccess = await _bookingRepository.DeleteBooking(bookingId);
                _response.Result = isSuccess;


            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
