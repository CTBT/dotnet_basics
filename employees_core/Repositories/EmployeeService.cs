using EmployeeCore.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeCore.Repositories;

public class EmployeeService(ILogger<EmployeeService> _logger, EmployeeRepo repo)
{
    
    public Employee? Task1()
    {
        _logger.LogInformation("----- Result task 1 (employee-name): ------");
        throw new NotImplementedException();
    }
    
    public IEnumerable<string> Task2(Employee employee)
    {
        _logger.LogInformation("----- Result task 2 (skill-names): ------");
        throw new NotImplementedException();
    }
    
    public int Task3()
    {
        _logger.LogInformation("----- Result task 3 (employee-counts): ------");
        throw new NotImplementedException();
    }
    
    public IOrderedEnumerable<Employee> Task4()
    {
        _logger.LogInformation("----- Result task 4 (database experts in bonn): ------");
        throw new NotImplementedException();
    }
    
    public Dictionary<Skill, int> Task5()
    {
        _logger.LogInformation("----- Result task 5 (employees per skill): ------");
        throw new NotImplementedException();
    }
    
    public Dictionary<Location, int> Task6()
    {
        _logger.LogInformation("----- Result task 6 (employees per location ordered): ------");
        throw new NotImplementedException();
    }
}