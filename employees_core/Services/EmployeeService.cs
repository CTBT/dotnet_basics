using EmployeeCore.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeCore.Services;

public class EmployeeService(ILogger<EmployeeService> _logger)
{
    
    public Employee? Task1_GetEmployee()
    {
        _logger.LogInformation("----- Result task 1 (employee-name): ------");
        throw new NotImplementedException();
    }
    
    public IEnumerable<string> Task2_GetSkillNames(Employee employee)
    {
        _logger.LogInformation("----- Result task 2 (skill-names): ------");
        throw new NotImplementedException();
    }
    
    public int Task3_GetEmployeeCounts(int skillId)
    {
        _logger.LogInformation("----- Result task 3 (employee-counts): ------");
        throw new NotImplementedException();
    }
    
    public IOrderedEnumerable<Employee> Task4_GetExperts(int skillId, Location location)
    {
        _logger.LogInformation("----- Result task 4 (database experts in bonn): ------");
        throw new NotImplementedException();
    }
    
    public Dictionary<Skill, int> Task5_GetEmployeesPerSkill()
    {
        _logger.LogInformation("----- Result task 5 (employees per skill): ------");
        throw new NotImplementedException();
    }
    
    public Dictionary<Location, int> Task6_GetEmployeesPerLocation()
    {
        _logger.LogInformation("----- Result task 6 (employees per location ordered): ------");
        throw new NotImplementedException();
    }
}