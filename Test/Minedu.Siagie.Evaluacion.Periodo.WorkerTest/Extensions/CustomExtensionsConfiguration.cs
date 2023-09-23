using Minedu.Fw.General.Models.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minedu.Siagie.Evaluacion.Periodo.WorkerTest.Extensions
{
    public static class CustomExtensionsConfiguration
    {
        public static IServiceCollection RegisterConfigurationServices(this IServiceCollection service, HostBuilderContext context)
        {

            //var queueSettings = new QueueConfiguration();
            //context.Configuration.GetSection("QueueConfiguration").Bind(queueSettings);
            //service.AddSingleton(queueSettings);

            //var informeProgreso = new InformeProgresoConfiguration();
            //context.Configuration.GetSection("InformeProgresoConfiguration").Bind(informeProgreso);
            //service.AddSingleton(informeProgreso);

            return service;
        }
    }
}
