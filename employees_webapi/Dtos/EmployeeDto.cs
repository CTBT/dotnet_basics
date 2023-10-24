using EmployeeCore.Models;

namespace employees_webapi.Dtos;

public class EmployeeDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Location { get; set; }

    public IEnumerable<string> Skills { get; set; }
}