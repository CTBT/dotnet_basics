using Microsoft.Extensions.Logging;

namespace EmployeeCore.Logging;

public static class LoggingConfiguration
{
    public static ILoggerFactory GetLoggingFactory()
    {
        var loggerFactory = LoggerFactory.Create(builder =>
            builder
                .AddFilter("Microsoft", LogLevel.Warning)
                .AddFilter("System", LogLevel.Warning)
                .AddFilter("EmployeeConsole", LogLevel.Information)
                .AddConsole()
        );

        return loggerFactory;
    }
}