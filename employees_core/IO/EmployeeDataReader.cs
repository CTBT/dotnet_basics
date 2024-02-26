using System.Text.Json;
using EmployeeCore.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeCore.IO;

public class EmployeeDataReader(ILogger<EmployeeDataReader> logger) : IEmployeeDataReader
{
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
        logger.LogDebug("Read employee file");
        return ReadFile<Employee>("Resources/employees.json");
    }

    /// <summary>
    /// Read skills.json file.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Skill> ReadSkillsFile()
    {
        logger.LogDebug("Read skills file");
        return ReadFile<Skill>("Resources/skills.json");
    }

}