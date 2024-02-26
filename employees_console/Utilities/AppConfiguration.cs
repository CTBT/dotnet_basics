using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EmployeeConsole.Utilities;

public static class AppConfiguration
{
    static AppConfiguration()
    {
        AppLoggerFactory = GetLoggingFactory();
    }
    private static readonly ILoggerFactory AppLoggerFactory;
    private static ILoggerFactory GetLoggingFactory()
    {
        return LoggerFactory
            .Create(builder => 
                builder.AddConfiguration(GetConfig().GetSection("Logging"))
                .AddSimpleConsole(options =>
                {
                    options.IncludeScopes = true;
                    options.SingleLine = true;
                    options.TimestampFormat = "HH:mm:ss ";
                })
                );
    }

    public static ILogger<T> GetLogger<T>()
    {
        return AppLoggerFactory.CreateLogger<T>();
    }

    private static IConfiguration GetConfig()
    {
        return  new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
    }
}