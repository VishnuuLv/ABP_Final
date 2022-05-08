using Flight.Services.ManageAPI.Models.Dto;
using Flight.Services.ManageAPI.RabbitMQSender;
using Flight.Services.ManageAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.ManageAPI.Controllers
{
    [Route("api/Flights")]
    [Authorize(Policy = "Admin")]
    public class ManageAPIController : Controller
    {
        protected ResponseDto _response;
        private IAirlineRepository _airlineRepository;
        private readonly IRabbitMQAirlineSender _rabbitMQairlineSender;


        public ManageAPIController(IAirlineRepository airlineRepository, IRabbitMQAirlineSender rabbitMQairlineSender)
        {
            _airlineRepository = airlineRepository;
            this._response = new ResponseDto();
            _rabbitMQairlineSender = rabbitMQairlineSender;

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

                LogsDto log = new LogsDto();
                log.log= "New Airline was added with flight ID " + model.flightId + " by Admin";
                log.task = "Create";
                log.senderAPI = "ManageAPI";

                
                //rabbitMQ
                 _rabbitMQairlineSender.SendData(log, "logqueue");
                _rabbitMQairlineSender.SendData(airline, "managedataqueue");



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

                AirlineViewDto airDto = await _airlineRepository.GetAirlineById(model.flightId);
                AirlineViewDto airline = airDto;

                LogsDto log = new LogsDto();
                log.log = model.flightId + " - Airline was updated  by Admin";
                log.task = "Update";
                log.senderAPI = "ManageAPI";


                //rabbitMQ
                _rabbitMQairlineSender.SendData(log, "logqueue");
               // _rabbitMQairlineSender.SendData(airline, "managedataqueue");
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

                AirlineViewDto airDto = await _airlineRepository.GetAirlineById(id);
                AirlineViewDto airline = airDto;

                LogsDto log = new LogsDto();
                log.log = id + " - Airline was deleted  by Admin";
                log.task = "Delete";
                log.senderAPI = "ManageAPI";


                //rabbitMQ
                _rabbitMQairlineSender.SendData(log, "logqueue");
               // _rabbitMQairlineSender.SendData(airline, "managedataqueue");


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
