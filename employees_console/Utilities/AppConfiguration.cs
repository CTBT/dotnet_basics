using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EmployeeConsole.Utilities;

public static class AppConfiguration
{
    public static ILoggerFactory GetLoggingFactory()
    {
        return LoggerFactory
            .Create(builder => builder.AddConfiguration(GetConfig().GetSection("Logging")).AddConsole());
    }

    private static IConfiguration GetConfig()
    {
        return  new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
    }
}