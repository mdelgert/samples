namespace SampleAPI.Shared.Helpers;
public static class ConfigurationHelper
{
    public static ConfigurationModel Get()
    {
        var configuration = new ConfigurationModel
        {
            ConnectionString = Environment.GetEnvironmentVariable("ConnectionString")
        };
        return configuration;
    }
}