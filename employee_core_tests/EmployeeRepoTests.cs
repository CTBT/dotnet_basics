using EmployeeCore.IO;
using EmployeeCore.Models;
using EmployeeCore.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;

namespace employee_core_tests;

public class EmployeeRepoTests
{

    private EmployeeService SetupTest(IEnumerable<Employee> employeeTestData, IEnumerable<Skill> skillTestData)
    {
        var readerMoq = new Mock<IEmployeeRepository>();
        readerMoq.Setup(reader => reader.GetEmployeeData())
            .Returns(employeeTestData);
        readerMoq.Setup(reader => reader.GetSkillData())
            .Returns(skillTestData);
        
        return new EmployeeService(NullLogger<EmployeeService>.Instance, readerMoq.Object);
    }
    
    // write tests for the methods in the EmployeeService class
    // use descriptive test names
    // think about all possible inputs and outputs
    // use FluentAssertions library to write assertions: 
    // Objects: https://fluentassertions.com/basicassertions/
    // Collections:  https://fluentassertions.com/collections/
    
    [Fact]
    public void Task1_ShouldReturnCorrectEmployee()
    {
        // Arrange
        var testSkills = new List<Skill>()
        {
            new() { Id = 1, Name = "TestSkill1" },
            new() { Id = 2, Name = "TestSkill2" }
        };
        var testEmployees = new List<Employee>();
        
        var service = SetupTest(testEmployees, testSkills);
        
        // Act
        var result = service.Task1_GetEmployee();
        
        // Assert
        result.Should().NotBeNull();
        result.Should().Match<Employee>(i => i.Location == Location.Stuttgart && i.Name.StartsWith("Dr.") && i.Skills.Count() == 2);
    }
    
    [Fact]
    public void Task2_ReturnsCorrectEmployeeSkillNames()
    {
        // Arrange
        var service = GetService();
        var employee = new Employee
        {
            Id = 0,
            Name = "Tester",
            Skills = [1,2],
            Location = Location.Bonn
        };
        
        // Act
        var result = service.Task2_GetSkillNames(employee);
        
        // Assert
        result.Should().HaveCount(2);
        result.Should().ContainMatch("TestSkill1");
        result.Should().ContainMatch("TestSkill2");
    }
    
    [Fact]
    public void Task3_ShouldReturnCorrectCount()
    {
        // Arrange
        var service = GetService();
        
        // Act
        var result = service.Task3_GetEmployeeCounts(1);
        
        // Assert
        result.Should().Be(4);
    }
}