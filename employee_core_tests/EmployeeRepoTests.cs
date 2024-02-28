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
    
    // write tests for the methods in the EmployeeService class
    // use descriptive test names
    // think about all possible inputs and outputs
    // use FluentAssertions library to write assertions: 
    // Objects: https://fluentassertions.com/basicassertions/
    // Collections:  https://fluentassertions.com/collections/
    
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