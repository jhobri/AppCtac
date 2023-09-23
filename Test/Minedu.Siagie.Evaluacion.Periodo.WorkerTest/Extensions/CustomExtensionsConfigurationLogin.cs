using Minedu.Fw.General.Models.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minedu.Siagie.Evaluacion.Periodo.WorkerTest.Extensions
{
    public static class CustomExtensionsConfigurationLogin
    {
        public static IServiceCollection RegisterConfigurationLoginServices(this IServiceCollection service, HostBuilderContext context)
        {

            var securityCentralConfiguration = new SecurityCentralConfiguration();
            context.Configuration.GetSection("SecurityCentralConfiguration").Bind(securityCentralConfiguration);
            service.AddSingleton(securityCentralConfiguration);

            var requestConfiguration = new RequestConfiguration();
            context.Configuration.GetSection("RequestConfiguration").Bind(requestConfiguration);
            service.AddSingleton(requestConfiguration);

            var globalConfiguration = new GlobalConfiguration();
            context.Configuration.GetSection("GlobalConfiguration").Bind(globalConfiguration);
            service.AddSingleton(globalConfiguration);

            var msaAppDevModeConfiguration = new MsaAppDevModeConfiguration();
            context.Configuration.GetSection("MsaAppDevModeConfiguration").Bind(msaAppDevModeConfiguration);
            service.AddSingleton(msaAppDevModeConfiguration);

            var migradorConfiguration = new MigradorConfiguration();
            context.Configuration.GetSection("MigradorConfiguration").Bind(migradorConfiguration);
            service.AddSingleton(migradorConfiguration);
            
            return service;
        }
    }
}
