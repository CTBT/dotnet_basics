using EmployeeCore.IO;
using EmployeeCore.Logging;
using EmployeeCore.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeCore.Repositories;

public class EmployeeRepo
{
    private readonly ILogger<EmployeeRepo> _logger;
    private readonly IEmployeeDataReader _dataReader;
    
    /// <summary>
    /// Creates a new EmployeeRepo object.
    /// </summary>
    public EmployeeRepo(IEmployeeDataReader dataReader)
    {
        _logger = LoggingConfiguration.GetLoggingFactory().CreateLogger<EmployeeRepo>();
        _dataReader = dataReader;
    }

    /// <summary>
    /// Get an employee by it´s name.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Employee GetEmployee(int id)
    {
        var employees = _dataReader.ReadEmployeesFile();
        return employees.SingleOrDefault(i => i.Id == id)!;
    }

    /// <summary>
    /// Get employees list.
    /// </summary>
    /// <param name="skillFilter"></param>
    /// <param name="locationFilter"></param>
    /// <returns></returns>
    public IEnumerable<Employee> GetEmployees(string? skillFilter = null, Location? locationFilter = null)
    {
        var skills = GetSkills();
        var employees = _dataReader.ReadEmployeesFile();

        if (skillFilter is not null)
        {
            var skill = skills.Single(i => i.Name == skillFilter).Id;
            employees = employees.Where(i => i.Skills.Contains(skill));
        }

        if (locationFilter is not null)
        {
            employees = employees.Where(i => i.Location == locationFilter);
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