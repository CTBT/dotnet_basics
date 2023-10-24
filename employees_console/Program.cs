using EmployeeConsole.Helper;
using EmployeeConsole.services;
using Microsoft.Extensions.Logging;

var loggerFactory = LoggingConfiguration.GetLoggingFactory();
var logger = loggerFactory.CreateLogger<Program>();

logger.LogInformation("----- Employee-Console started. ------");

var repo = new EmployeeRepo();

// 1. pick one employee (pick from employees.json) and print his name and Location

// 2. print the name(not id) of the skills of that employee

// 3. print the number of employees with the skill 'Database':

// 4. print 10 of the employees with the skill 'Database' and the location 'Bonn'

// 5. print the number of employees per skill

// 6. Create a Dictionary with location as key and print the number of employees per location

logger.LogInformation("----- Employee-Console finished. ------");

Console.ReadKey();