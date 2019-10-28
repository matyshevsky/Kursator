using System;
using Autofac;
using Domain.FixingDomain.Interfaces;
using Kursator.Interfaces;
using Kursator.Services;
using Repositories.Repository;

namespace Kursator
{
    public class KursatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FixingService>().As<IFixingService>();
            builder.RegisterType<NbpProvider>().As<INbpProvider>();
            builder.Register(ctx =>
            {
                return new Uri("http://api.nbp.pl/api/");
            }).As<Uri>();
        }

    }
}
