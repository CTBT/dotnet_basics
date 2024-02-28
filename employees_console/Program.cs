using EmployeeConsole.Utilities;
using EmployeeCore.IO;
using EmployeeCore.Models;
using EmployeeCore.Services;
using Microsoft.Extensions.Logging;

// get main logger
var mainLogger = AppConfiguration.GetLogger<Program>();
mainLogger.LogInformation("----- Application started. ------");

// create instances
var repo = new EmployeeFileReader(AppConfiguration.GetLogger<EmployeeFileReader>());
var service = new EmployeeService(repo);

// Solve the tasks defined below
// methods that could be helpfull:
// .Select()
// .Count()
// .Take()
// .Single() / .SingleOrDefault()
// .First() / .FirstOrDefault()
// GroupBy()
// ToDictionary()
// OrderBy()


try
{
    // 1. find someone in stuttgart that has all skills and has a doctor degree (starts with "Dr.") and print his name
    var task1Result = service
        .GetEmployees(null, Location.Stuttgart)
        .FirstOrDefault(i => i.Name.StartsWith("Dr.") && i.Skills.Count( ) == service.GetSkills().Count());
    mainLogger.LogInformation("Task1 - Found {EmployeeName}", task1Result?.Name);
    
    // 2. print the skill-names of that employee
    var task2Result = service.GetEmployeeSkillNames(task1Result!);
    mainLogger.LogInformation("Task2 - Employee skills:{Skills}",string.Join(",", task2Result));

    // 3. print the number of employees with the skill 'Database':
    var task3Result = service.GetEmployeeCount(5);
    mainLogger.LogInformation("Task3 - Employees with skill \'Database\': {Count}", task3Result);

    // 4. print 5 of the employees with the skill 'Database' and the location 'Bonn' ordered by name
    var task4Result = service.GetEmployees(5, Location.Bonn)
        .Select(i => i.Name)
        .Take(5);
    
    mainLogger.LogInformation("Task4 - 5 employees with skill database in bonn:{Employees}",
        string.Join(",",task4Result));
    
    // 5. print the number of employees per skill
    var task5Results = service.GetEmployeesPerSkill();
    mainLogger.LogInformation("Task6 - Number of employees per skill:");
    foreach (var skillCount in task5Results)
    {
        mainLogger.LogInformation("Skill: {SkillName} - {Count}", skillCount.Key.Name, skillCount.Value);
    }
    
    // 6. Print the number of employees per location ordered by there number.
    var task6Result = service.GetEmployeesPerLocation();
    foreach (var pair in task6Result)
    {
        mainLogger.LogInformation("Location: {Location} - {Count} employees", 
            pair.Key.ToString(), 
            pair.Value.ToString());
    }
}
catch (NotImplementedException)
{
    mainLogger.LogCritical("The application crashed because of missing implementations :(");
}


mainLogger.LogInformation("----- Application finished. ------");

Console.ReadKey();