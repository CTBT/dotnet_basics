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

// 1. get employee with id=0 and print his name and location
service.Task1();

// 2. print the name(not id) of the skills of that employee
service.Task2();

// 3. print the number of employees with the skill 'Database':
service.Task3();

// 4. print 5 of the employees with the skill 'Database' and the location 'Bonn' ordered by name
service.Task4();

// 5. print the number of employees per skill

service.Task5();

// 6. Print the number of employees per location ordered by there number.
service.Task6();

mainLogger.LogInformation("----- Application finished. ------");

Console.ReadKey();