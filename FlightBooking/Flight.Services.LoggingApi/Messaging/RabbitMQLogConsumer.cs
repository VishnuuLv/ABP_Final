using AutoMapper;
using Flight.Services.LoggingApi.DbContexts;
using Flight.Services.LoggingApi.Model;
using Flight.Services.LoggingApi.Model.Dto;
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

namespace Flight.Services.LoggingApi.Messaging
{
    public class RabbitMQLogConsumer : BackgroundService
    {
        //private readonly ApplicationDbContext _db;
        private IMapper _mapper;
        private IConnection _connection;
        private IModel _channel;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public RabbitMQLogConsumer(IMapper mapper, IServiceScopeFactory serviceScopeFactory)
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
            _channel.QueueDeclare(queue: "logqueue", false, false, false, arguments: null);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                 //AddOrder(content);

                LogsDto logDto = JsonConvert.DeserializeObject<LogsDto>(content);
                 HandleMessage(logDto).GetAwaiter().GetResult();

                _channel.BasicAck(ea.DeliveryTag, false);
            };
            _channel.BasicConsume("logqueue", false, consumer);

            return Task.CompletedTask;
        }

        private  async Task HandleMessage(LogsDto logDto)
        {
            LogsDto logheader = new()
            {
                log = logDto.log,
                senderAPI = logDto.senderAPI,
                task=logDto.task
               
            };


            await AddOrder(logheader);




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



        public async  Task<bool> AddOrder(LogsDto logheader)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                Logs logdto = _mapper.Map<LogsDto, Logs>(logheader);
                //Logs logdto = new Logs();
                //logdto.log = message;
                logdto.createdDate = DateTime.Now;
                dbContext.logs.Add(logdto);
                await dbContext.SaveChangesAsync();
                //Do something here
            }
            
            return true;
        }
    }
}
