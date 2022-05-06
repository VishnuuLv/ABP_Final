using Flight.Services.CouponAPI.Models;
using Flight.Services.CouponAPI.Models.Dto;
using Flight.Services.CouponAPI.Repository;
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

        public CouponAPIController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
            this._response = new ResponseDto();

        }
        [HttpGet]
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
        [HttpPost]

        public async Task<object> Post([FromBody] CouponDto couponDto)
        {
            try
            {
                CouponDto model = await _couponRepository.CreateUpdateCoupon(couponDto);
                _response.Result = model;
                _response.DisplayMessage = Convert.ToString(model.couponId);

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
