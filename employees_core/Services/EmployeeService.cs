using EmployeeCore.IO;
using EmployeeCore.Models;

namespace EmployeeCore.Services;

public class EmployeeService(IEmployeeRepository repo)
{

    public IEnumerable<Skill> GetSkills()
    {
        return repo.GetSkillData();
    }
    public Employee? FindEmployee(int id)
    {
        return repo.GetEmployeeData()
            .SingleOrDefault(i => i.Id == id);
    }
    
    public IEnumerable<string> GetEmployeeSkillNames(Employee employee)
    {
        return employee.Skills
            .Join(repo.GetSkillData(), i => i, skill => skill.Id, (i, skill) => skill.Name);
    }
    
    public int GetEmployeeCount(int skillId)
    {
        return repo
            .GetEmployeeData()
            .Count(i => i.Skills.Contains(skillId));
    }
    
    public IOrderedEnumerable<Employee> GetEmployees(int? skillId, Location? location)
    {
        var data = repo.GetEmployeeData();

        if (skillId is not null)
        {
            data = data.Where(i => i.Skills.Contains((int)skillId));
        }

        if (location is not null)
        {
            data = data.Where(i => i.Location == location);
        }
        
        return data.OrderBy(i => i.Name);
    }
    
    public Dictionary<Skill, int> GetEmployeesPerSkill()
    {
        return repo.GetSkillData()
            .ToDictionary(skill => skill, skill => repo.GetEmployeeData()
                .Count(i => i.Skills.Contains(skill.Id)));
    }
    
    public Dictionary<Location, int> GetEmployeesPerLocation()
    {
        return repo.GetEmployeeData()
            .GroupBy(i => i.Location)
            .ToDictionary(t=> t.Key, t=> t.Count())
            .OrderBy(i => i.Value)
            .ToDictionary();
    }
}