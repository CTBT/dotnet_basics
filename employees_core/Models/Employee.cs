namespace EmployeeCore.Models;

public class Employee
{
    public required int Id { get; set; }

    public required string Name { get; set; }

    public IEnumerable<int> Skills { get; set; } = new List<int>();

    public required Location Location { get; set; }
}