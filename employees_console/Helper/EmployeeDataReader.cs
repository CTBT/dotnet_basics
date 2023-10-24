using System.Text.Json;
using EmployeeConsole.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeConsole.Helper;

public class EmployeeDataReader
{
    private readonly ILogger<EmployeeDataReader> _logger;

    public EmployeeDataReader()
    {
        var factory = LoggingConfiguration.GetLoggingFactory();
        _logger = factory.CreateLogger<EmployeeDataReader>();
    }
    
    /// <summary>
    /// Read employees.json file
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Employee> ReadEmployeesFile()
    {
        _logger.LogDebug("Read employee file");
        var jsonString = File.ReadAllText("Resources/employees.json");
        return JsonSerializer.Deserialize<IEnumerable<Employee>>(jsonString) ?? new List<Employee>();
    }

    /// <summary>
    /// Read skills.json file.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Skill> ReadSkillsFile()
    {
        _logger.LogDebug("Read skills file");
        var jsonString = File.OpenRead("Resources/skills.json");
        return JsonSerializer.Deserialize<List<Skill>>(jsonString) ?? new List<Skill>();
    }

}