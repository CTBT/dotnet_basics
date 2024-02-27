using EmployeeCore.IO;
using EmployeeCore.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeCore.Services;

public class EmployeeService(ILogger<EmployeeService> _logger, EmployeeFileReader repo)
{
    
    public Employee? Task1()
    {
        _logger.LogInformation("----- Result task 1 (employee-name): ------");
        
        return repo.GetEmployeeData()
            .FirstOrDefault(i => i.Skills.Count( ) == 11 && i.Location == Location.Stuttgart && i.Name.StartsWith("Dr."));
    }
    
    public IEnumerable<string> Task2(Employee employee)
    {
        _logger.LogInformation("----- Result task 2 (skill-names): ------");
        
        return employee.Skills
            .Join(repo.GetSkillData(), i => i, skill => skill.Id, (i, skill) => skill.Name);
    }
    
    public int Task3()
    {
        _logger.LogInformation("----- Result task 3 (employee-counts): ------");
        
        return repo
            .GetEmployeeData()
            .Count(i => i.Skills.Contains(5));
    }
    
    public IOrderedEnumerable<Employee> Task4()
    {
        _logger.LogInformation("----- Result task 4 (database experts in bonn): ------");
        return repo
            .GetEmployeeData()
            .Where(i => i.Skills.Contains(5) && i.Location == Location.Bonn)
            .Take(5)
            .OrderBy(i => i.Name);
    }
    
    public Dictionary<Skill, int> Task5()
    {
        _logger.LogInformation("----- Result task 5 (employees per skill): ------");

        return repo.GetSkillData()
            .ToDictionary(skill => skill, skill => repo.GetEmployeeData()
                .Count(i => i.Skills.Contains(skill.Id)));
    }
    
    public Dictionary<Location, int> Task6()
    {
        _logger.LogInformation("----- Result task 6 (employees per location ordered): ------");

        return repo.GetEmployeeData()
            .GroupBy(i => i.Location)
            .ToDictionary(t=> t.Key, t=> t.Count())
            .OrderBy(i => i.Value).ToDictionary();
    }
}