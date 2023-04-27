using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Confluent.Kafka;
using kafka_worker_service.Helpers;
using kafka_worker_service.Models;


// TODO: add namespaces

namespace kafka_worker_service.Services
{
    public class UserRegistrationWorker : BackgroundService
    {
        // TODO: appsettings dependency injection

private readonly ConsumerConfig _config;
public UserRegistrationWorker(ConsumerConfig config)
{
_config = config;
}

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine($"Worker started...");

            while (!stoppingToken.IsCancellationRequested)
            {
                // TODO: worker logic
                var consumerHelper = new ConsumerHelper(_config, "user-registration");
                string message = consumerHelper.ReadMessage();
                //Deserilaize
                UserRegistrationModel user = JsonConvert.DeserializeObject<UserRegistrationModel>(message);
                //TODO:: Process Order
                Console.WriteLine($"---Info: User Registered: {message}---");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
