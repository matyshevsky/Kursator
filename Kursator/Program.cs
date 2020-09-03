using Autofac;
using Kursator.Interfaces;
using System;
using NLog;

namespace Kursator
{
    class Program
    {
        private static IContainer Container { get; set; }
        
        static void Main(string[] args)
        {
            var logger = LogManager.GetCurrentClassLogger();
            try
            {
                
                logger.Info("Start application.");

                logger.Info("Registry modules...");
                var builder = new ContainerBuilder();
                builder.RegisterModule<KursatorModule>();
                Container = builder.Build();
                logger.Info("The container was built");

                using (var scope = Container.BeginLifetimeScope())
                {
                    logger.Info("Resolving fixing service...");
                    var service = scope.Resolve<IFixingService>();
                    logger.Info("done.");
                    logger.Info("Get rates for 5 currency...");
                    var result = service.GetWorldwideFixings().Result;
                    logger.Info("done.");

                    foreach (var item in result)
                    {
                        logger.Info($"{item.CurrencyCode}: {item.Rate}");
                    }

                }

                logger.Info("End application..");
            }
            catch (Exception e)
            {
                logger.Error(e);
            }


        }
    }
}
