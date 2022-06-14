using Microsoft.EntityFrameworkCore;

namespace SampleAPI.Tests
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services, HostBuilderContext hostBuilderContext)
        {
            EnvironmentSetupHelper.GetVariables();
            var configurationShared = ConfigurationHelper.Get();
            var db = new DbHelper();
            services.AddSingleton(_ => db);
            services.AddSingleton(_ => configurationShared);
            services.AddSingleton<INoteService, NoteService>();
        }
    }
}