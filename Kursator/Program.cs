using Autofac;
using Kursator.Interfaces;
using System;

namespace Kursator
{
    class Program
    {
        private static IContainer Container { get; set; }
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<KursatorModule>();
            Container = builder.Build();

            using (var scope = Container.BeginLifetimeScope())
            {
                var service = scope.Resolve<IFixingService>();
                var result = service.GetWorldwideFixings().Result;
            }
        }
    }
}
