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
    public class RabbitMQCouponConsumer : BackgroundService
    {
        //private readonly ApplicationDbContext _db;
        private IMapper _mapper;
        private IConnection _connection;
        private IModel _channel;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public RabbitMQCouponConsumer(IMapper mapper, IServiceScopeFactory serviceScopeFactory)
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
            _channel.QueueDeclare(queue: "coupondataqueue", false, false, false, arguments: null);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                //AddOrder(content);

                CouponViewDto coupondto = JsonConvert.DeserializeObject<CouponViewDto>(content);
                HandleMessage(coupondto).GetAwaiter().GetResult();

                _channel.BasicAck(ea.DeliveryTag, false);
            };
            _channel.BasicConsume("coupondataqueue", false, consumer);

            return Task.CompletedTask;
        }

        private async Task HandleMessage(CouponViewDto coupondto)
        {
            CouponViewDto couponheader = new()
            {
                //flightId = airdto.flightId,
                couponCode = coupondto.couponCode,
                maxAmount = coupondto.maxAmount,
                discountPercentage = coupondto.discountPercentage,
                flightId = coupondto.flightId,
                validityStartDate = coupondto.validityStartDate,
                validityEndDate = coupondto.validityEndDate,
                createdDate = coupondto.createdDate,
                updatedDate = coupondto.updatedDate,
                isActive = coupondto.isActive

            };


            await AddOrder(couponheader);




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



        public async Task<bool> AddOrder(CouponViewDto couponviewdto)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                Coupon coupondto = _mapper.Map<CouponViewDto, Coupon>(couponviewdto);
                //Logs logdto = new Logs();
                //logdto.log = message;
                // logdto.createdDate = DateTime.Now;
                dbContext.coupons.Add(coupondto);
                await dbContext.SaveChangesAsync();
                //Do something here
            }

            return true;
        }
    }
}
