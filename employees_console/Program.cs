using EmployeeConsole.Helper;
using EmployeeConsole.Models;
using EmployeeConsole.services;
using Microsoft.Extensions.Logging;

var loggerFactory = LoggingConfiguration.GetLoggingFactory();
var logger = loggerFactory.CreateLogger<Program>();

logger.LogInformation("----- Employee-Console started. ------");

var repo = new EmployeeRepo();

// 1. pick one employee (pick from employees.json) and print his name and Location
var employee = repo.GetEmployee("Daniel Thatcher");
logger.LogInformation($"Hello {employee.Name}. Here are your details:");
logger.LogInformation("Employee-Location:" + employee.Location);

// 2. print the skill names of that employee
var skillNames = employee.Skills.Select(i => repo.GetSkillName(i));
logger.LogInformation("Employee-Skills:" + string.Join(",", skillNames));

// 3. print count of employees with the skill 'Database':
var employeesWithDatabaseSkill = repo.GetEmployees("Database");
logger.LogInformation($"Employees with skill 'Database': {employeesWithDatabaseSkill.Count()}");

// 4. print 10 of the employees with the skill 'Database' and the location 'Bonn'
var firstTenEmployees = employeesWithDatabaseSkill.Where(i => i.Location == Location.Bonn).Select(i => i.Name).Take(10);
logger.LogInformation($"10 employees with skill database in bonn:{string.Join(",",firstTenEmployees) }");

// 5. print the number of employees per skill
logger.LogInformation("--- Skill-Counts ----");
foreach (Skill skill in repo.GetSkills())
{
    var employeesWithSkill = repo.GetEmployees(skill.Name);
    logger.LogInformation($"Skill: {skill.Name} - Count:{employeesWithSkill.Count()}");
}

// 6. Create a Dictionary with location as key and print the number of employees per location
var dic = new Dictionary<Location, IEnumerable<Employee>>();

var employees = repo.GetEmployees();
employees.GroupBy(i => i.Location)
    .ToDictionary(t=> t.Key, t=> t.Select(r=> r.Name).ToList());

logger.LogInformation("----- Employee-Console finished. ------");

Console.ReadKey();