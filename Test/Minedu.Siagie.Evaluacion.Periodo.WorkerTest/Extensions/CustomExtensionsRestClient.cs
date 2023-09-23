using Minedu.Fw.Api.Rest;
using Minedu.Siagie.Rest.Service.Configuration;

namespace Minedu.Siagie.Evaluacion.Periodo.WorkerTest.Extensions
{
    public static class CustomExtensionsRestClient
    {
        public static void AddRestCustomClient<T>(this IServiceCollection services, string serviceName)
            where T : class
        {
            var clientName = typeof(T).ToString();
            var options = ConfigureOptions(services);
            ConfigureDefaultClient<T>(services, clientName, serviceName, options);
            ConfigureForwarder<T>(services, clientName);
        }

        private static ServiceRestUrl ConfigureOptions(IServiceCollection services)
        {
            IConfiguration configuration;
            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }

            services.Configure<ServiceRestUrl>(configuration.GetSection("ServiceRest"));

            return configuration.GetOptions<ServiceRestUrl>("ServiceRest");
        }

        private static void ConfigureDefaultClient<T>(IServiceCollection services, string clientName,
            string serviceName, ServiceRestUrl options) where T : class
        {
            services.AddTransient<AuthenticationHttpMessageBGSHandler<T>>();
            services.AddHttpClient(clientName, client =>
            {
                var service = options.Services.SingleOrDefault(s => s.Name.Equals(serviceName,
                    StringComparison.InvariantCultureIgnoreCase));
                if (service == null)
                {
                    throw new ServiceRestNotFoundException($"ServiceRest service: '{serviceName}' was not found.",
                        serviceName);
                }

                client.BaseAddress = new UriBuilder
                {
                    Scheme = service.Scheme,
                    Host = service.Host,
                    Port = service.Port,
                    Path = service.GatewayPath
                }.Uri;
                //client.DefaultRequestHeaders.Add("Accept", "application/json");
                //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJpYXQiOjE2NTUxNzk4NDIsImp0aSI6IjRhYmM1YjAwLWI3M2YtNGExNC1hOWE0LWY5NDJlN2Y0YWNlNSIsImFndyI6IkludC1zaWFnaWUtbXNhLWFwaS0yMDQ4IiwidXNlciI6IkpHUkFOQURPUyIsInJvbCI6IjAxMSIsIm5iZiI6MTY1NTE3OTgyMiwiZXhwIjoxNjU1MTc5ODcyLCJpc3MiOiJNU0EtU2lhZ2llU2VydmVyLnY0IiwiYXVkIjoiTVNBLVNpYWdpZUNsaWVudC52NCJ9.OO0oOYTYt8hwhIUsntyNYTPphPcsECkoU5xed-UA1NYiAFUF6GrXkU2gZuxITuEGnRzEuZmHJfMpPm6ECt0JE2qx5nrnwdbx73ybuaiTXghC7gmtj8KomapA6PRO2E_dPLOCWi-ZpWR75dgGvxRbArpxmllwLc7U4cKnHeh3AvcwOVQcvnaSKviyvgkn-uzAx5Y3Ecf1fA93PgOdUD-XTyOGU79ZXNnPtVOAoYOUFkA1JMRUv--PMT03tA0xckNjl2iIApx86aeS24050iKs9abk8Rr_kZaVEw5WMqTxNFhI84JQ7c62-J0GxAmAVRdKxXOmjVHw_pSSOXy6GTflNw");
            })
            .AddHttpMessageHandler<AuthenticationHttpMessageBGSHandler<T>>()
            ;
        }

        private static void ConfigureForwarder<T>(IServiceCollection services, string clientName) where T : class
        {
            services.AddTransient(c => new RestClient(c.GetService<IHttpClientFactory>().CreateClient(clientName))
            {
                RequestQueryParamSerializer = new QueryParamSerializer()
            }
            .For<T>()
            );
        }
    }
}