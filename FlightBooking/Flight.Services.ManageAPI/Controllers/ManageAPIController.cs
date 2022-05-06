using Flight.Services.ManageAPI.Models.Dto;

using Flight.Services.ManageAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.ManageAPI.Controllers
{
    [Route("api/Flights")]
    public class ManageAPIController : Controller
    {
        protected ResponseDto _response;
        private IAirlineRepository _airlineRepository;
       

        public ManageAPIController(IAirlineRepository airlineRepository)
        {
            _airlineRepository = airlineRepository;
            this._response = new ResponseDto();
            

        }
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<AirlineViewDto> airlineDtos = await _airlineRepository.GetAirlines();
                _response.Result = airlineDtos;
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
                AirlineViewDto airlineDtos = await _airlineRepository.GetAirlineById(id);
                _response.Result = airlineDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return _response;
        }
        [HttpPost]
        
        public async Task<object> Post([FromBody] AirlineDto airlineDto)
        {
            try
            {
                AirlineDto model = await _airlineRepository.CreateUpdateAirline(airlineDto);
                _response.Result = model;
                _response.DisplayMessage =Convert.ToString(model.flightId);

                AirlineViewDto airDto = await _airlineRepository.GetAirlineById(model.flightId);
                AirlineViewDto airline = airDto;
                ////rabbitMQ
                

            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            
            return _response;
        }

        
        [HttpPut]
        
        public async Task<object> Put([FromBody] AirlineDto airlineDto)
        {
            try
            {
                AirlineDto model = await _airlineRepository.CreateUpdateAirline(airlineDto);
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
                bool isSuccess = await _airlineRepository.DeleteAirline(id);
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
