using EmployeeCore.Models;

namespace EmployeeCore.IO;

public interface IEmployeeRepository
{
    /// <summary>
    /// Read employees.json file
    /// </summary>
    /// <returns></returns>
    IEnumerable<Employee> GetEmployeeData();

    /// <summary>
    /// Read skills.json file.
    /// </summary>
    /// <returns></returns>
    IEnumerable<Skill> GetSkillData();
}