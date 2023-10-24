using EmployeeCore.Models;
using EmployeeCore.Repositories;
using employees_webapi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace employees_webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController
{
    private readonly EmployeeRepo _repo;

    public EmployeeController(EmployeeRepo repo)
    {
        _repo = repo;
    }
    
    [HttpGet("{employeeId}")]
    public EmployeeDto GetEmployee(int employeeId)
    {
        var employee = _repo.GetEmployee(employeeId);
        var skills = _repo.GetSkills();
        return new EmployeeDto
        {
            Id = employee.Id,
            Name = employee.Name,
            Location = employee.Location.ToString(),
            Skills =  employee.Skills.Select(i => skills.Single(j => j.Id == i).Name)
        };
    }
    
    [HttpGet]
    public IEnumerable<EmployeeDto> GetEmployees(string skillFilter = null, Location? locationFilter = null)
    {
        return _repo.GetEmployees(skillFilter, locationFilter).Select(i => new EmployeeDto
        {
            Id = i.Id,
            Name = i.Name,
            Location = i.Location.ToString()
        }).Take(100);
    }
}