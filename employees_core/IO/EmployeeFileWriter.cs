using System.Text.Json;
using EmployeeCore.Models;

namespace EmployeeCore.IO;

public static class EmployeeFileWriter
{
    public static void WriteEmployeesFile()
    {
        var jsonString = File.OpenRead("Resources/skills.json");
        var skills = JsonSerializer.Deserialize<List<Skill>>(jsonString)!.ToList();
        var testdata = new List<Employee>();
        for (int i = 0; i < 10000; i++)
        {
            testdata.Add(new Employee
            {
                Id = i,
                Name = Faker.Name.FullName(),
                Location = Faker.Enum.Random<Location>(),
                Skills = Enumerable.Range(1, Random.Shared.Next(0, skills.Count)+1)
            });
        }
        
        var data = JsonSerializer.Serialize<IEnumerable<Employee>>(testdata);
        File.WriteAllText("Resources/employees.json", data);
    }
}