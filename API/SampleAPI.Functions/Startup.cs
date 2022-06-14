[assembly: FunctionsStartup(typeof(Startup))]

namespace SampleAPI.Functions;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        var configurationShared = ConfigurationHelper.Get();
        var db = new DbHelper();
        builder.Services.AddSingleton(_ => db);
        builder.Services.AddSingleton(_ => configurationShared);
        builder.Services.AddSingleton<INoteService, NoteService>();
    }
}