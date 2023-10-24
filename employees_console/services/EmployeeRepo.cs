using EmployeeConsole.Helper;
using EmployeeConsole.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeConsole.services;

public class EmployeeRepo
{
    private readonly ILogger<EmployeeRepo> _logger;
    private readonly EmployeeDataReader _dataReader;
    
    /// <summary>
    /// Creates a new EmployeeRepo object.
    /// </summary>
    public EmployeeRepo()
    {
        _logger = LoggingConfiguration.GetLoggingFactory().CreateLogger<EmployeeRepo>();
        _dataReader = new EmployeeDataReader();
    }

    /// <summary>
    /// Get an employee by it´s name.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Employee GetEmployee(string name)
    {
        var employees = _dataReader.ReadEmployeesFile();
        return employees.FirstOrDefault(i => i.Name == name)!;
    }

    /// <summary>
    /// Get employees list.
    /// </summary>
    /// <param name="skillFilter"></param>
    /// <returns></returns>
    public IEnumerable<Employee> GetEmployees(string? skillFilter = null)
    {
        var skills = GetSkills();
        var employees = _dataReader.ReadEmployeesFile();

        if (skillFilter is not null)
        {
            var skill = skills.Single(i => i.Name == skillFilter).Id;
            employees = employees.Where(i => i.Skills.Contains(skill));
        }
        
        return employees;
    }

    /// <summary>
    /// Get the name of a skill.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetSkillName(int id)
    {
        var skills = _dataReader.ReadSkillsFile().ToList();

        return skills.Single(i => i.Id == id).Name;
    }
    
    /// <summary>
    /// Get employee skills.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Skill> GetSkills()
    {
        var skills = _dataReader.ReadSkillsFile().ToList();

        return skills;
    }
}