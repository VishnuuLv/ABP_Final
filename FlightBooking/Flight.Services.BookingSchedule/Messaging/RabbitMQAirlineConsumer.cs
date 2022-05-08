using AutoMapper;
using Flight.Services.BookingSchedule.DbContexts;
using Flight.Services.BookingSchedule.Models;
using Flight.Services.BookingSchedule.Models.Dto;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flight.Services.BookingSchedule.Messaging
{
    public class RabbitMQAirlineConsumer : BackgroundService
    {
        //private readonly ApplicationDbContext _db;
        private IMapper _mapper;
        private IConnection _connection;
        private IModel _channel;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public RabbitMQAirlineConsumer(IMapper mapper, IServiceScopeFactory serviceScopeFactory)
        {
            //_db = db;
            _mapper = mapper;
            _serviceScopeFactory = serviceScopeFactory;

            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "managedataqueue", false, false, false, arguments: null);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                //AddOrder(content);

                AirlineViewDto airdto = JsonConvert.DeserializeObject<AirlineViewDto>(content);
                HandleMessage(airdto).GetAwaiter().GetResult();

                _channel.BasicAck(ea.DeliveryTag, false);
            };
            _channel.BasicConsume("managedataqueue", false, consumer);

            return Task.CompletedTask;
        }

        private async Task HandleMessage(AirlineViewDto airdto)
        {
            AirlineViewDto airheader = new()
            {
                //flightId = airdto.flightId,
                flightName = airdto.flightName,
                contactNumber = airdto.contactNumber,
                contactAddress = airdto.contactAddress,
                logoURL = airdto.logoURL,
                createdDate = airdto.createdDate,
                updatedDate = airdto.updatedDate,
                isActive = airdto.isActive

            };


            await AddOrder(airheader);




            try
            {
                //await _messageBus.PublishMessage(paymentRequestMessage, orderPaymentProcessTopic);
                //await args.CompleteMessageAsync(args.Message);
                // _rabbitMQOrderMessageSender.SendMessage(paymentRequestMessage, "orderpaymentprocesstopic");
            }
            catch (Exception)
            {
                throw;
            }
        }



        public async Task<bool> AddOrder(AirlineViewDto airheader)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                Airline airdto = _mapper.Map<AirlineViewDto, Airline>(airheader);
                //Logs logdto = new Logs();
                //logdto.log = message;
               // logdto.createdDate = DateTime.Now;
                dbContext.Flight.Add(airdto);
                await dbContext.SaveChangesAsync();
                //Do something here
            }

            return true;
        }
    }
}
