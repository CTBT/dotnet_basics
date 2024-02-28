using System.Text.Json;
using EmployeeCore.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeCore.IO;

public class EmployeeFileReader(ILogger<EmployeeFileReader> logger, string path) : IEmployeeRepository
{
    private IEnumerable<T> ReadFile<T>(string fileName)
    {
        var combinedPath = Path.Combine(path, fileName);
        var jsonString = File.ReadAllText(combinedPath);
        return JsonSerializer.Deserialize<IEnumerable<T>>(jsonString) ?? new List<T>();
    }
    
    /// <summary>
    /// Read employees.json file
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Employee> GetEmployeeData()
    {
        logger.LogDebug("Full employee list read operation");
        return ReadFile<Employee>("employees.json");
    }

    /// <summary>
    /// Read skills.json file.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Skill> GetSkillData()
    {
        logger.LogDebug("Full skill list read operation");
        return ReadFile<Skill>("skills.json");
    }

}