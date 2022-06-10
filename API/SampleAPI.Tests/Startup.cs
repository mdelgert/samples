namespace SampleAPI.Tests
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services, HostBuilderContext hostBuilderContext)
        {
            EnvironmentSetup.GetVariables();
            //var configurationShared = ConfigurationHelper.Get();
            //services.AddSingleton(_ => configurationShared);
            //services.AddSingleton<ITest, Test>();
        }
    }
}
