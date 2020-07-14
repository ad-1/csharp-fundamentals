using System;
using System.Collections.Generic;
using System.Text;

namespace Company
{
    public class Employee
    {

        public double Id { get; }
        public string Name { get; set; }
        public string Role { get; set; }

        public Employee(double id, string name, string role)
        {
            this.Id = id;
            this.Name = name;
            this.Role = role;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Role: {Role}");
        }

    }

}
