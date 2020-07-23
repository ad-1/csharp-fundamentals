using System;
using System.Collections.Generic;

namespace Reflect
{
    class Program
    {
        static void Main(string[] args)
        {
            var employees = CreateCollectionOf(typeof(List<>), typeof(Employee));
            // var employees = CreateCollection(typeof(List<Employee>));
            // var employees = new List<Employee>();
            Console.Write(employees.GetType().Name); // List`1
            var genericArgs = employees.GetType().GenericTypeArguments;
            foreach(var arg in genericArgs)
            {
                Console.Write("[{0}]", arg.Name);
            }
            Console.WriteLine();

            var employee = new Employee();
            var employeeType = employee.GetType(); // typeof(Employee)
            var methodInfo = employeeType.GetMethod("Speak");
            methodInfo = methodInfo.MakeGenericMethod(typeof(DateTime));
            methodInfo.Invoke(employee, null);

        }

        private static object CreateCollection(Type type)
        {
            return Activator.CreateInstance(type);
        }

        private static object CreateCollectionOf(Type collectionType, Type itemType)
        {
            var closedType = collectionType.MakeGenericType(itemType);
            return Activator.CreateInstance(closedType);
        }

    }

    public class Employee
    {
        public string Name { get; set; }

        public void Speak<T>()
        {
            Console.WriteLine(typeof(T).Name);
        }

    }

}
