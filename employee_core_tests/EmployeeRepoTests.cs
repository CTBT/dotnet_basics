using EmployeeCore.IO;
using EmployeeCore.Models;
using EmployeeCore.Services;
using FluentAssertions;
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
        
        return new EmployeeService(readerMoq.Object);
    }
    
    // write tests for the methods in the EmployeeService class
    // use descriptive test names
    // think about all possible inputs and outputs
    // use FluentAssertions library to write assertions: 
    // Objects: https://fluentassertions.com/basicassertions/
    // Collections:  https://fluentassertions.com/collections/
    // bonus: use a Theory do define multiple test cases
    
    [Fact]
    public void Task1()
    {
        // Arrange
        var testSkills = new List<Skill>()
        {
            new() { Id = 1, Name = "TestSkill1" },
            new() { Id = 2, Name = "TestSkill2" }
        };
        var testEmployees = new List<Employee>()
        {
            new Employee()
            {
                Id = 0,
                Location = Location.Bonn,
                Name = "TestUser1"
            },
            new Employee()
            {
                Id = 1,
                Location = Location.Bonn,
                Name = "TestUser2"
            }
        };
        
        var service = SetupTest(testEmployees, testSkills);
        
        // Act
        var result = service.FindEmployee(0);
        
        // Assert
        result.Should().NotBeNull();
        result.Should().Match<Employee>(i => i.Id == 0);
        result.Should().Match<Employee>(i => i.Name == "TestUser1");
    }
}