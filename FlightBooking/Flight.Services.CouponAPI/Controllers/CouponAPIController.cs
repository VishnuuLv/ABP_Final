using Flight.Services.CouponAPI.Models;
using Flight.Services.CouponAPI.Models.Dto;
using Flight.Services.CouponAPI.RabbitMQSender;
using Flight.Services.CouponAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.CouponAPI.Controllers
{
    [Route("api/Coupon")]
    public class CouponAPIController : Controller
    {
        protected ResponseDto _response;
        private ICouponRepository _couponRepository;
        private readonly IRabbitMQAirlineSender _rabbitMQairlineSender;

        public CouponAPIController(ICouponRepository couponRepository, IRabbitMQAirlineSender rabbitMQairlineSender)
        {
            _couponRepository = couponRepository;
            _rabbitMQairlineSender = rabbitMQairlineSender;
            this._response = new ResponseDto();

        }
        [HttpGet]
        [Authorize(Policy = "Admin")]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<CouponViewDto> couponeDtos = await _couponRepository.GetCoupon();
                _response.Result = couponeDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                CouponViewDto couponDtos = await _couponRepository.GetCouponById(id);
                _response.Result = couponDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return _response;
        }

        [HttpGet]
        [Route("GetCouponByName/{couponCode}")]
        public async Task<object> GetCouponByName(string couponCode)
        {
            try
            {
                CouponViewDto couponDtos = await _couponRepository.GetCouponByName(couponCode);
                _response.Result = couponDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return _response;
        }
        [HttpPost]

        public async Task<object> Post([FromBody] CouponDto couponDto)
        {
            try
            {
                CouponDto model = await _couponRepository.CreateUpdateCoupon(couponDto);
                _response.Result = model;
                _response.DisplayMessage = Convert.ToString(model.couponId);

                CouponViewDto coupondto = await _couponRepository.GetCouponById(model.couponId);
                CouponViewDto coupon = coupondto;

                LogsDto log = new LogsDto();
                log.log = "New Coupon was added with Coupon ID " + model.couponId + " by Admin";
                log.task = "Create";
                log.senderAPI = "CouponAPI";


                //rabbitMQ
                _rabbitMQairlineSender.SendData(log, "logqueue");
                _rabbitMQairlineSender.SendData(coupon, "coupondataqueue");

            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpPut]

        public async Task<object> Put([FromBody] CouponDto couponDto)
        {
            try
            {
                CouponDto model = await _couponRepository.CreateUpdateCoupon(couponDto);
                _response.Result = model;

                CouponViewDto coupondto = await _couponRepository.GetCouponById(model.couponId);
                CouponViewDto coupon = coupondto;

                LogsDto log = new LogsDto();
                log.log = model.couponId + " Coupon was updated by Admin";
                log.task = "Update";
                log.senderAPI = "CouponAPI";


                //rabbitMQ
                _rabbitMQairlineSender.SendData(log, "logqueue");
                //_rabbitMQairlineSender.SendData(coupon, "managedataqueue");
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<object> Post(int id)
        {
            try
            {
                bool isSuccess = await _couponRepository.DeleteCoupon(id);
                _response.Result = isSuccess;

                CouponViewDto coupondto = await _couponRepository.GetCouponById(id);
                CouponViewDto coupon = coupondto;

                LogsDto log = new LogsDto();
                log.log = id + " Coupon was Deleted by Admin";
                log.task = "Delete";
                log.senderAPI = "CouponAPI";


                //rabbitMQ
                _rabbitMQairlineSender.SendData(log, "logqueue");
                //_rabbitMQairlineSender.SendData(coupon, "managedataqueue");


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
