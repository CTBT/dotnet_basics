using EmployeeCore.IO;
using EmployeeCore.Repositories;
using Microsoft.Extensions.Logging.Abstractions;

namespace employee_core_tests;

public class EmployeeRepoTests
{

    private EmployeeService GetService()
    {
        var reader = new EmployeeDataReader(NullLogger<EmployeeDataReader>.Instance);
        var repo = new EmployeeRepo(reader);
        return new EmployeeService(NullLogger<EmployeeService>.Instance, repo);
    }
    
    [Fact]
    public void Task1()
    {
        // Arrange
        var service = GetService();
        
        // Act
        var result = service.Task1();
        
        // Assert
        Assert.True(false);
    }
}