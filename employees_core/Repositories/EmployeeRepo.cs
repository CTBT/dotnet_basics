using EmployeeCore.IO;
using EmployeeCore.Models;

namespace EmployeeCore.Repositories;

public class EmployeeRepo
{
    private readonly IEmployeeDataReader _dataReader;
    
    /// <summary>
    /// Creates a new EmployeeRepo object.
    /// </summary>
    public EmployeeRepo(IEmployeeDataReader dataReader)
    {
        _dataReader = dataReader;
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
    /// Get employee skills.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Skill> GetSkills()
    {
        var skills = _dataReader.ReadSkillsFile().ToList();

        return skills;
    }
}