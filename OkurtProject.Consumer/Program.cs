using System;
using GreenPipes;
using MassTransit;
using OkurtProject.Contract;

namespace OkurtProject.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Consumer";

            var bus = BusConfigurator.ConfigureBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(RabbitMqConsts.ExampleQueueName, e =>
                {
                    e.Consumer<IExampleCommandConsumer>();
                    e.UseCircuitBreaker(cb =>
                    {
                        cb.TrackingPeriod = TimeSpan.FromMinutes(1);
                        cb.TripThreshold = 15;
                        cb.ActiveThreshold = 10;
                        cb.ResetInterval = TimeSpan.FromMinutes(5);
                    });
                });
            });

            bus.StartAsync();

            Console.WriteLine("Queue eritilmek için dinlenmekte. " + "Çıkmak için enter tuşuna basınız");
            
            Console.ReadLine();

            bus.StopAsync();
        }
    }
}