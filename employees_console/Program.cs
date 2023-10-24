using EmployeeCore.IO;
using EmployeeCore.Logging;
using EmployeeCore.Repositories;
using Microsoft.Extensions.Logging;

var logger = LoggingConfiguration.GetLoggingFactory().CreateLogger<Program>();

logger.LogInformation("----- Employee-Console started. ------");
var repo = new EmployeeRepo(new EmployeeDataReader());

// 1. get employee with id=0 and print his name and location

// 2. print the name(not id) of the skills of that employee

// 3. print the number of employees with the skill 'Database':

// 4. print 10 of the employees with the skill 'Database' and the location 'Bonn' ordered by name

// 5. print the number of employees per skill

// 6. Print the number of employees per location ordered by there number.

logger.LogInformation("----- Employee-Console finished. ------");

// methods that could be helpfull:
// .Select()
// .Count()
// .Take()
// GroupBy()
// ToDictionary()
// OrderBy()

Console.ReadKey();