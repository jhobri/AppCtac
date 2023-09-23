namespace Back.Ctac.Rest.Service.Configuration;

public class ServiceRestNotFoundException : Exception
{
    public string ServiceName { get; set; }

    public ServiceRestNotFoundException(string serviceName) : this(string.Empty, serviceName)
    {
    }

    public ServiceRestNotFoundException(string message, string serviceName) : base(message)
    {
        ServiceName = serviceName;
    }
}