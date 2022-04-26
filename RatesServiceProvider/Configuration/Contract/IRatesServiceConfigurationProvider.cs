
namespace ExternalServiceProviders.Configuration.Contract
{
    public interface IRatesServiceConfigurationProvider
    {
        string BaseAddress { get; }
        string ApiKey { get; }
    }
}
