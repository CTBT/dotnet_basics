using EmployeeCore.Models;

namespace EmployeeCore.IO;

public interface IEmployeeDataReader
{
    /// <summary>
    /// Read employees.json file
    /// </summary>
    /// <returns></returns>
    IEnumerable<Employee> ReadEmployeesFile();

    /// <summary>
    /// Read skills.json file.
    /// </summary>
    /// <returns></returns>
    IEnumerable<Skill> ReadSkillsFile();
}