using EmployeeCore.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeCore.Services;

public class EmployeeService(ILogger<EmployeeService> _logger)
{
    
    public Employee? Task1_GetEmployee()
    {
        _logger.LogInformation("----- Result task 1 (employee-name): ------");
        
        return repo.GetEmployeeData()
            .FirstOrDefault(i => i.Skills.Count( ) == 11 && i.Location == Location.Stuttgart && i.Name.StartsWith("Dr."));
    }
    
    public IEnumerable<string> Task2_GetSkillNames(Employee employee)
    {
        _logger.LogInformation("----- Result task 2 (skill-names): ------");
        
        return employee.Skills
            .Join(repo.GetSkillData(), i => i, skill => skill.Id, (i, skill) => skill.Name);
    }
    
    public int Task3_GetEmployeeCounts(int skillId)
    {
        _logger.LogInformation("----- Result task 3 (employee-counts): ------");
        
        return repo
            .GetEmployeeData()
            .Count(i => i.Skills.Contains(skillId));
    }
    
    public IOrderedEnumerable<Employee> Task4_GetExperts(int skillId, Location location)
    {
        _logger.LogInformation("----- Result task 4 (database experts in bonn): ------");
        return repo
            .GetEmployeeData()
            .Where(i => i.Skills.Contains(skillId) && i.Location == location)
            .Take(5)
            .OrderBy(i => i.Name);
    }
    
    public Dictionary<Skill, int> Task5_GetEmployeesPerSkill()
    {
        _logger.LogInformation("----- Result task 5 (employees per skill): ------");

        return repo.GetSkillData()
            .ToDictionary(skill => skill, skill => repo.GetEmployeeData()
                .Count(i => i.Skills.Contains(skill.Id)));
    }
    
    public Dictionary<Location, int> Task6_GetEmployeesPerLocation()
    {
        _logger.LogInformation("----- Result task 6 (employees per location ordered): ------");

        return repo.GetEmployeeData()
            .GroupBy(i => i.Location)
            .ToDictionary(t=> t.Key, t=> t.Count())
            .OrderBy(i => i.Value).ToDictionary();
    }
}