namespace EmployeeConsole.Models;

public class Employee
{
    public required Guid Id { get; set; }

    public required string Name { get; set; }

    public IEnumerable<int> Skills { get; set; } = new List<int>();

    public required Location Location { get; set; }
}