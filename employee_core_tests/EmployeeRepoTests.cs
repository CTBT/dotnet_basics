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
    public void FindEmployeeById_ShouldFindEmployee()
    {
        // Arrange
        var testSkills = new List<Skill>
        {
            new() { Id = 1, Name = "TestSkill1" },
            new() { Id = 2, Name = "TestSkill2" }
        };
        var testEmployees = new List<Employee>
        {
            new() { Id = 0, Name = "Testnutzer 1", Location = Location.Stuttgart },
            new() { Id = 1, Name = "Testnutzer 2", Location = Location.Bonn},
        };
        
        var service = SetupTest(testEmployees, testSkills);   
        
        // Act
        var result = service.FindEmployee(1);
        
        // Assert
        result.Should().NotBeNull();
        result.Should().Match<Employee>(i => i.Name == "Testnutzer 2");

    }
    
    [Fact]
    public void GetEmployees_ShouldReturnCorrectEmployees()
    {
        // Arrange
        var testSkills = new List<Skill>
        {
            new() { Id = 1, Name = "TestSkill1" },
            new() { Id = 2, Name = "TestSkill2" }
        };
        var testEmployees = new List<Employee>
        {
            new() { Id = 0, Name = "Dr. Tester Stuttgart1", Location = Location.Stuttgart, Skills = [1, 2] },
            new() { Id = 1, Name = "Dr. Tester Stuttgart2", Location = Location.Stuttgart, Skills = [1]  },
            new() { Id = 2, Name = "Dr. Tester Bonn", Skills = [1, 2], Location = Location.Bonn },
            new() { Id = 3, Name = "Tester1", Skills = [1], Location = Location.Bonn },
            new() { Id = 4, Name = "Tester2", Skills = [], Location = Location.Bonn }
        };
        
        var service = SetupTest(testEmployees, testSkills);
        
        // Act
        var result = service.GetEmployees(1, Location.Stuttgart);
        
        // Assert
        result.Should().NotBeNull();
        result.Should().AllSatisfy(i => i.Location = Location.Stuttgart);
        result.Should().AllSatisfy(i => i.Skills.Contains(1));
    }
    
    [Fact]
    public void GetEmployeeSkillNames_ReturnsCorrectEmployeeSkillNames()
    {
        // Arrange
        var testSkills = new List<Skill>
        {
            new() { Id = 1, Name = "TestSkill1" },
            new() { Id = 2, Name = "TestSkill2" }
        };
        var testEmployees = new List<Employee>();
        var service = SetupTest(testEmployees, testSkills);
        var employee = new Employee
        {
            Id = 0,
            Name = "Tester",
            Skills = [1,2],
            Location = Location.Bonn
        };
        
        // Act
        var result = service.GetEmployeeSkillNames(employee);
        
        // Assert
        result.Should().HaveCount(2);
        result.Should().ContainMatch("TestSkill1");
        result.Should().ContainMatch("TestSkill2");
    }
    
    [Fact]
    public void GetEmployeeCount_ShouldReturnCorrectCount()
    {
        // Arrange
        var testSkills = new List<Skill>
        {
            new() { Id = 1, Name = "TestSkill1" },
            new() { Id = 2, Name = "TestSkill2" }
        };
        var testEmployees = new List<Employee>
        {
            new() { Id = 2, Name = "Dr. Tester Bonn", Skills = [1, 2], Location = Location.Bonn },
            new() { Id = 3, Name = "Tester1", Skills = [1], Location = Location.Bonn },
            new() { Id = 4, Name = "Tester2", Skills = [], Location = Location.Bonn }
        };
        
        var service = SetupTest(testEmployees, testSkills);
        
        // Act
        var result = service.GetEmployeeCount(1);
        
        // Assert
        result.Should().Be(2);
    }

    [Fact]
    public void GetEmployeesPerSkill_ShouldContainAllSkills()
    {
        // Arrange
        var testSkills = new List<Skill>
        {
            new() { Id = 1, Name = "TestSkill1" },
            new() { Id = 2, Name = "TestSkill2" }
        };
        var testEmployees = new List<Employee>();
        
        var service = SetupTest(testEmployees, testSkills);
        
        // Act
        var result = service.GetEmployeesPerSkill();
        
        // Assert
        result.Should().ContainKeys(testSkills);
    }
    
    [Fact]
    public void GetEmployeesPerSkill_ShouldReturnCorrectCounts()
    {
        // Arrange
        var testSkills = new List<Skill>
        {
            new() { Id = 1, Name = "TestSkill1" },
            new() { Id = 2, Name = "TestSkill2" }
        };
        var testEmployees = new List<Employee>
        {
            new() { Id = 1, Name = "Tester1", Skills = [1, 2], Location = Location.Bonn },
            new() { Id = 2, Name = "Tester2", Skills = [1, 2], Location = Location.Bonn },
            new() { Id = 3, Name = "Tester3", Skills = [1], Location = Location.Bonn },
            new() { Id = 4, Name = "Tester4", Skills = [], Location = Location.Bonn }
        };
        
        var service = SetupTest(testEmployees, testSkills);
        
        // Act
        var result = service.GetEmployeesPerSkill();
        
        // Assert
        result[testSkills[0]].Should().Be(3);
        result[testSkills[1]].Should().Be(2);
    }
}