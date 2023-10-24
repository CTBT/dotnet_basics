using EmployeeCore.IO;
using EmployeeCore.Repositories;

namespace employee_core_tests;

public class EmployeeRepoTests
{
    [Fact]
    public void GetEmployee_ReturnsEmployee()
    {
        // Arrange
        var reader = new EmployeeDataReader();
        var repo = new EmployeeRepo(reader);

        // Act
        var result = repo.GetEmployee(1);

        // Assert
        Assert.True(result.Name == "Tester1");
        result.Name.Should().Be("Tester1");
    }
    
// Make sure the following conditions are fulfilled:
// 0. GetEmployee return null if the id was not found.
// 1. GetEmployees returns the correct list of all employees when no filter is applied
// 2. GetEmployees applies filters correctly
    // Count
    // OnlyContain
// 3. GetSkillName returns an error if the skill is not found ( use https://fluentassertions.com/exceptions/)
// 4. GetSkillName returns the name of the skill.
// 5. GetSkills returns the correct list of skills
// 6. GetSkills return a list of UNIQUE skills - make it green
}