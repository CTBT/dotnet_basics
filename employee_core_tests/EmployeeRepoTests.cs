using EmployeeCore.IO;
using EmployeeCore.Services;
using Microsoft.Extensions.Logging.Abstractions;

namespace employee_core_tests;

public class EmployeeRepoTests
{

    private EmployeeService GetService()
    {
        var reader = new EmployeeFileReader(NullLogger<EmployeeFileReader>.Instance);
        return new EmployeeService(NullLogger<EmployeeService>.Instance, reader);
    }
    
    [Fact]
    public void Task1()
    {
        // Arrange
        var service = GetService();
        
        // Act
        var result = service.Task1_GetEmployee();
        
        // Assert
        Assert.True(false);
    }
}