

namespace Back.Ctac.Rest.Service.Configuration;

public class ServiceRestUrl
{
    
    public string LoadBalancer { get; set; }
    public IEnumerable<Service> Services { get; set; }
    public class Service
    {
        public string Name { get; set; }
        public string Scheme { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string GatewayPath { get; set; }
    }
}
