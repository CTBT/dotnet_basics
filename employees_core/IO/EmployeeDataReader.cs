using System.Text.Json;
using EmployeeCore.Logging;
using EmployeeCore.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeCore.IO;

public class EmployeeDataReader : IEmployeeDataReader
{
    private readonly ILogger<EmployeeDataReader> _logger;

    public EmployeeDataReader()
    {
        var factory = LoggingConfiguration.GetLoggingFactory();
        _logger = factory.CreateLogger<EmployeeDataReader>();
    }
    
    public static IEnumerable<T> ReadFile<T>(string fileName)
    {
        var jsonString = File.ReadAllText(fileName);
        return JsonSerializer.Deserialize<IEnumerable<T>>(jsonString) ?? new List<T>();
    }
    
    /// <summary>
    /// Read employees.json file
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Employee> ReadEmployeesFile()
    {
        _logger.LogDebug("Read employee file");
        return ReadFile<Employee>("Resources/employees.json");
    }

    /// <summary>
    /// Read skills.json file.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Skill> ReadSkillsFile()
    {
        _logger.LogDebug("Read skills file");
        return ReadFile<Skill>("Resources/skills.json");
    }

}