using EmployeeConsole.Utilities;
using EmployeeCore.IO;
using EmployeeCore.Models;
using EmployeeCore.Repositories;
using Microsoft.Extensions.Logging;

// setup logging
var loggerFactory = AppConfiguration.GetLoggingFactory();

// get logger
var mainLogger = loggerFactory.CreateLogger<Program>();

mainLogger.LogInformation("----- Application started. ------");

// create EmployeeRepo instance
var repo = new EmployeeRepo(new EmployeeDataReader(loggerFactory.CreateLogger<EmployeeDataReader>()));

// Solve the following tasks
// methods that could be helpfull:
// .Select()
// .Count()
// .Take()
// .Single() / .SingleOrDefault()
// .First() / .FirstOrDefault()
// GroupBy()
// ToDictionary()
// OrderBy()

// 1. get employee with id=0 and print his name and location
mainLogger.LogInformation("----- Result task 1 (employee-name): ------");
var employee = repo.GetEmployees().SingleOrDefault(i => i.Id == 0);
mainLogger.LogInformation("Hello {EmployeeName}. Here is your location {Location}: ", 
    employee.Name, 
    employee.Location);

// 2. print the employees skills by there names
mainLogger.LogInformation("----- Result task 2 (skill-names): ------");
var skillNames = employee.Skills
    .Join(repo.GetSkills(), i => i, skill => skill.Id, (i, skill) => skill.Name);
mainLogger.LogInformation("Employee skills:{Skills}",string.Join(",", skillNames));

// 3. print the number of employees with the skill 'Database':
mainLogger.LogInformation("----- Result task 3 (employee-counts): ------");
var employeesWithDatabaseSkill = repo.GetEmployees("Database");
mainLogger.LogInformation("Employees with skill \'Database\': {Count}", employeesWithDatabaseSkill.Count());

// 4. print 5 of the employees with the skill 'Database' and the location 'Bonn' ordered by name
mainLogger.LogInformation("----- Result task 4 (database experts in bonn): ------");
var employeesFiltered = repo
    .GetEmployees("Database", Location.Bonn)
    .Select(i => i.Name)
    .Take(5)
    .OrderBy(i => i);

mainLogger.LogInformation("5 employees with skill database in bonn:{Employees}",
    string.Join(",",employeesFiltered));

// 5. print the number of employees per skill
mainLogger.LogInformation("----- Result task 5 (employees per skill): ------");
mainLogger.LogInformation("--- Skill-Counts ----");

var result = repo.GetSkills()
    .ToDictionary(skill => skill.Name, skill => repo.GetEmployees(skill.Name));
foreach (var skillCount in result)
{
    mainLogger.LogInformation("Skill: {SkillName} - Count:{Count}", skillCount.Key, skillCount.Value.Count());
}

// var result = repo.GetSkills().ToDictionary(skill => skill.Name, skill => repo.GetEmployees(skill.Name).Count());

// 6. Print the number of employees per location ordered by there number.
mainLogger.LogInformation("----- Result task 6 (employees per location ordered): ------");

var employeesDictionary = repo.GetEmployees()
    .GroupBy(i => i.Location)
    .ToDictionary(t=> t.Key, t=> t.Count())
    .OrderBy(i => i.Value);

foreach (var pair in employeesDictionary)
{
    mainLogger.LogInformation("Location: {Location} - {Count} employees", 
        pair.Key.ToString(), 
        pair.Value.ToString());
}

mainLogger.LogInformation("----- Employee-Console finished. ------");

Console.ReadKey();