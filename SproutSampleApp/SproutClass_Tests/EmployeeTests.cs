using Moq;
using SproutClass;

namespace SproutClass_Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void GetEmployeesData_ReturnsSalaries()
        {
            var currentData = new Mock<IEmployeeService>();
            currentData.Setup(x => x.GetEmployeesData()).Returns(new List<Employee>() { new Employee { UniqueId = 1, Salary = 100 } });
            var salaryData = currentData.Object.GetEmployeesData();

            Assert.True(salaryData.Count > 0);
            Assert.Contains(salaryData, x => x.Salary > 0);
            Assert.NotEmpty(salaryData);
        }
    }
}