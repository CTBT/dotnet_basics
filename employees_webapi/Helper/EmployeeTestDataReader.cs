using EmployeeCore.IO;
using EmployeeCore.Models;

namespace employees_webapi.Helper;

public class EmployeeTestDataReader : IEmployeeDataReader
{
    /// <summary>
    /// Read employees.json file
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Employee> ReadEmployeesFile()
    {
        return EmployeeDataReader.ReadFile<Employee>("Resources/employees_test.json");
    }

    /// <summary>
    /// Read skills.json file.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Skill> ReadSkillsFile()
    {
        return EmployeeDataReader.ReadFile<Skill>("Resources/skills_test.json");
    }
}