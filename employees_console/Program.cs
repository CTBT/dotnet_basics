using EmployeeConsole.Utilities;
using EmployeeCore.IO;
using EmployeeCore.Repositories;
using Microsoft.Extensions.Logging;

// get main logger
var mainLogger = AppConfiguration.GetLogger<Program>();
mainLogger.LogInformation("----- Application started. ------");

// create instances
var repo = new EmployeeRepo(new EmployeeDataReader(AppConfiguration.GetLogger<EmployeeDataReader>()));
var service = new EmployeeService(AppConfiguration.GetLogger<EmployeeService>(), repo);

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
    var task1Result = service.Task1();
    mainLogger.LogInformation("Found {EmployeeName}", task1Result?.Name);

    // 2. print the skill-names of that employee
    var task2Result = service.Task2(task1Result!);
    mainLogger.LogInformation("Employee skills:{Skills}",string.Join(",", task2Result));

    // 3. print the number of employees with the skill 'Database':
    var task3Result = service.Task3();
    mainLogger.LogInformation("Employees with skill \'Database\': {Count}", task3Result);

    // 4. print 5 of the employees with the skill 'Database' and the location 'Bonn' ordered by name
    var task4Result = service.Task4();
    mainLogger.LogInformation("5 employees with skill database in bonn:{Employees}",
        string.Join(",",task4Result.Select(i => i.Name)));

    // 5. print the number of employees per skill
    var task5Results = service.Task5();
    foreach (var skillCount in task5Results)
    {
        mainLogger.LogInformation("Skill: {SkillName} - {Count}", skillCount.Key.Name, skillCount.Value);
    }

    // 6. Print the number of employees per location ordered by there number.
    var task6Result = service.Task6();
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