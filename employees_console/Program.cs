using EmployeeCore.IO;
using EmployeeCore.Logging;
using EmployeeCore.Models;
using EmployeeCore.Repositories;
using Microsoft.Extensions.Logging;

var logger = LoggingConfiguration.GetLoggingFactory().CreateLogger<Program>();

logger.LogInformation("----- Employee-Console started. ------");
var repo = new EmployeeRepo(new EmployeeDataReader());

// 1. get employee with id=0 and print his name and location
var employee = repo.GetEmployee(0);
logger.LogInformation("Hello {EmployeeName}. Here are your details:", employee.Name);
logger.LogInformation("Employee location: {EmployeeLocation}", employee.Location);

// 2. print the name(not id) of the skills of that employee
var skillNames = employee.Skills.Select(i => repo.GetSkillName(i));
logger.LogInformation("Employee skills:{Skills}",string.Join(",", skillNames));

// 3. print the number of employees with the skill 'Database':
var employeesWithDatabaseSkill = repo.GetEmployees("Database");
logger.LogInformation("Employees with skill \'Database\': {Count}", employeesWithDatabaseSkill.Count());

// 4. print 10 of the employees with the skill 'Database' and the location 'Bonn' ordered by name
var employeesFiltered = repo
    .GetEmployees("Database", Location.Bonn)
    .Select(i => i.Name)
    .Take(10)
    .OrderBy(i => i);
logger.LogInformation("10 employees with skill database in bonn:{Employees}", string.Join(",",employeesFiltered));

// 5. print the number of employees per skill
logger.LogInformation("--- Skill-Counts ----");
foreach (Skill skill in repo.GetSkills())
{
    var employeesWithSkill = repo.GetEmployees(skill.Name);
    logger.LogInformation("Skill: {SkillName} - Count:{Count}", skill.Name, employeesWithSkill.Count());
}

// 6. Print the number of employees per location ordered by there number.
var employeesDictionary = repo.GetEmployees()
    .GroupBy(i => i.Location)
    .ToDictionary(t=> t.Key, t=> t.Count())
    .OrderBy(i => i.Value);

foreach (var pair in employeesDictionary)
{
    logger.LogInformation("Location: {location} - {count} employees", pair.Key.ToString(), pair.Value.ToString());
}

logger.LogInformation("----- Employee-Console finished. ------");

// methods that could be helpfull:
// .Select()
// .Count()
// .Take()
// GroupBy()
// ToDictionary()
// OrderBy()

Console.ReadKey();