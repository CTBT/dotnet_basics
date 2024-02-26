using EmployeeCore.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeCore.Services;

public class EmployeeService()
{
    
    public Employee? Task1_GetEmployee()
    {
        throw new NotImplementedException();
    }
    
    public IEnumerable<string> Task2_GetSkillNames(Employee employee)
    {
        throw new NotImplementedException();
    }
    
    public int Task3_GetEmployeeCounts(int skillId)
    {
        throw new NotImplementedException();
    }
    
    public IOrderedEnumerable<Employee> Task4_GetExperts(int skillId, Location location)
    {
        throw new NotImplementedException();
    }
    
    public Dictionary<Skill, int> Task5_GetEmployeesPerSkill()
    {
        throw new NotImplementedException();
    }
    
    public Dictionary<Location, int> Task6_GetEmployeesPerLocation()
    {
        throw new NotImplementedException();
    }
}