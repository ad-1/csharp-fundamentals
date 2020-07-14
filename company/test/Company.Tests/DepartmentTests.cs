using System;
using Xunit;
using System.Collections.Generic;
using Company.Linq;

namespace Company.Tests
{
    public class DepartmentTests
    {
        [Fact]
        public void EmployeeCountTest()
        {
            var engineering = new Department(DepartmentName.Engineering);
            AddEmployeesToDepartment(engineering);
            Assert.Equal(5, engineering.EmployeeCount);
        }

        [Fact]
        public void GetEmployeesWithinIdRangeTest()
        {
            var manufacturing = new Department(DepartmentName.Manufacturing);
            AddEmployeesToDepartment(manufacturing);
            IEnumerable<Employee> employees = manufacturing.GetEmployeesWithinIdRange(1, 4);
            Assert.Equal(2, employees.Count());
        }

        private void AddEmployeesToDepartment(Department dept)
        {
            IEnumerator<Employee> enumerator = CreateNewEmployees().GetEnumerator();
            while (enumerator.MoveNext())
            {
                dept.AddEmployee(enumerator.Current);
            }
        }

        private IEnumerable<Employee> CreateNewEmployees()
        {
            return new Employee[5]
                        {
                new Employee(0, "Andy", "On-Demand Developer"),
                new Employee(1, "Adam", "GTEUSI APplications Developer"),
                new Employee(2, "Toba", "Display Innovation Sales"),
                new Employee(3, "Declan", "Customer Introduction"),
                new Employee(4, "Conor", "QA Tester")
                        };
        }

    }
}
