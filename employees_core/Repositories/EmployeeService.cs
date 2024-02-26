using Microsoft.Extensions.Logging;

namespace EmployeeCore.Repositories;

public class EmployeeService(ILogger<EmployeeService> _logger, EmployeeRepo repo)
{
    
    public void Task1()
    {
        _logger.LogInformation("----- Result task 1 (employee-name): ------");
        
        _logger.LogError("Missing implementation");
    }
    
    public void Task2()
    {
        _logger.LogInformation("----- Result task 2 (skill-names): ------");
        
        _logger.LogError("Missing implementation");
    }
    
    public void Task3()
    {
        _logger.LogInformation("----- Result task 3 (employee-counts): ------");
        
        _logger.LogError("Missing implementation");
    }
    
    public void Task4()
    {
        _logger.LogInformation("----- Result task 4 (database experts in bonn): ------");
        
        _logger.LogError("Missing implementation");
    }
    
    public void Task5()
    {
        _logger.LogInformation("----- Result task 5 (employees per skill): ------");
        
        _logger.LogError("Missing implementation");
    }
    
    public void Task6()
    {
        _logger.LogInformation("----- Result task 6 (employees per location ordered): ------");
        
        _logger.LogError("Missing implementation");
    }
}