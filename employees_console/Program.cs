using EmployeeConsole.Utilities;
using EmployeeCore.IO;
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
mainLogger.LogError("Missing implementation");

// 2. print the name(not id) of the skills of that employee
mainLogger.LogInformation("----- Result task 2 (skill-names): ------");
mainLogger.LogError("Missing implementation");

// 3. print the number of employees with the skill 'Database':
mainLogger.LogInformation("----- Result task 3 (employee-counts): ------");
mainLogger.LogError("Missing implementation");

// 4. print 5 of the employees with the skill 'Database' and the location 'Bonn' ordered by name
mainLogger.LogInformation("----- Result task 4 (database experts in bonn): ------");
mainLogger.LogError("Missing implementation");

// 5. print the number of employees per skill
mainLogger.LogInformation("----- Result task 5 (employees per skill): ------");
mainLogger.LogError("Missing implementation");

// 6. Print the number of employees per location ordered by there number.
mainLogger.LogInformation("----- Result task 6 (employees per location ordered): ------");
mainLogger.LogError("Missing implementation");

mainLogger.LogInformation("----- Application finished. ------");

Console.ReadKey();