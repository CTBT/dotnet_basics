using Microsoft.Extensions.Logging;

namespace EmployeeConsole.Helper;

public class LoggingConfiguration
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