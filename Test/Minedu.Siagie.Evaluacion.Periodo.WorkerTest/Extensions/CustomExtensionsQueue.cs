using MassTransit;
using Minedu.Fw.General.Models.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minedu.Siagie.Evaluacion.Periodo.WorkerTest.Extensions
{
    public static class CustomExtensionsQueue
    {
        //public static IServiceCollection RegisterQueueServices(this IServiceCollection services, HostBuilderContext context)
        //{
        //    var queueSettings = new QueueConfiguration();
        //    context.Configuration.GetSection("QueueConfiguration").Bind(queueSettings);

        //    services.AddMassTransit(c =>
        //    {
        //        c.AddConsumer<GeneracionInformeProgresoPeriodoSeccionIntegrationConsumer>();
        //        c.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
        //        {
        //            cfg.Host(new Uri(queueSettings.HostName), h =>
        //            {
        //                h.Username(queueSettings.UserName);
        //                h.Password(queueSettings.Password);
        //            });
        //        }));
        //    });
        //    return services;
        //}
    }
}
