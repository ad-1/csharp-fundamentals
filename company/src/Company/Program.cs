using System;
using System.Collections.Generic;

namespace Company
{
    class Program
    {
        static void Main(string[] args)
        {
            var engineering = new Department(DepartmentName.Engineering);

            var developers = new Employee[5]
                        {
                new Employee(0, "Andy", "On-Demand Developer"),
                new Employee(1, "Adam", "GTEUSI APplications Developer"),
                new Employee(2, "Toba", "Display Innovation Sales"),
                new Employee(3, "Declan", "Customer Introduction"),
                new Employee(4, "Conor", "QA Tester")
                        };
            foreach (Employee developer in developers)
            {
                engineering.AddEmployee(developer);
            }

            Console.WriteLine("\n ***** Employees in Engineering:");
            foreach (Employee employee in engineering)
            {
                employee.ShowDetails();
            }

            Console.WriteLine("\n ***** Employees in Engineering Alphabetical Order:");
            engineering.ListEmplyeesAlphabetically();

            Console.ReadLine();
        }

    }
}
