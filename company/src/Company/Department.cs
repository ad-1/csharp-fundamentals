using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Company
{
    public class Department: IEnumerable<Employee>
    {

        public DepartmentName Name { get; }
        private readonly Dictionary<double, Employee> employeeRegister;

        public int EmployeeCount
        {
            get
            {
                return employeeRegister.Count;
            }
        }

        public Department(DepartmentName name)
        {
            this.Name = name;
            this.employeeRegister = new Dictionary<double, Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            employeeRegister[employee.Id] = employee;
        }

        public Employee GetEmployeeById(double id)
        {
            return employeeRegister[id];
        }

        public IEnumerable<Employee> GetEmployeesWithinIdRange(double lowerId, double upperId)
        {
            return employeeRegister.Values.Where(e => (e.Id < upperId && e.Id > lowerId));
        }

        public void ListEmplyeesAlphabetically()
        {
            foreach(Employee employee in employeeRegister.Values
                .OrderBy(e => e.Name))
            {
                Console.WriteLine(employee.Name);
            }
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            foreach(Employee employee in this.employeeRegister.Values)
            {
                yield return employee;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

}
