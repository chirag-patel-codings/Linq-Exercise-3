using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine("\nSum:\nWith LINQ Method:");
            Console.WriteLine($"Sum: {numbers.Sum()}");

            
            //TODO: Print the Average of numbers
            Console.WriteLine("\n\nAverage:\nWith LINQ Method:");
            Console.WriteLine($"Average: {numbers.Average()}");

            //TODO: Order numbers in ascending order and print to the console
            Console.WriteLine("\n\nSort:\nWith LINQ Method:");
            var sortASCNumbersByMethod = numbers.OrderBy(n => n).ToList();
            sortASCNumbersByMethod.ForEach(n => Console.Write($"{n}, "));
            
            //TODO: Order numbers in descending order and print to the console
            Console.WriteLine("\n\nSort Descending:\nWith LINQ Method:");
            var sortDESCNumbersByMethod = numbers.OrderByDescending(n => n).ToList();
            sortDESCNumbersByMethod.ForEach(n => Console.Write($"{n}, "));

            //TODO: Print to the console only the numbers greater than 6
            Console.WriteLine("\n\nFiltering > 6:\nWith LINQ Method:");
            var numbersGreaterThanSixWithMethod = numbers.Where(n => n > 6).ToList();
            numbersGreaterThanSixWithMethod.ForEach(n => Console.Write($"{n}, "));

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("\n\nTaking Top 4 by making ASC:\nWith LINQ Method:");
            var ascNumbers = numbers.OrderBy(n => n).Take(4).ToList();
            foreach(var ascNumber in ascNumbers)
            {
                Console.Write($"{ascNumber}, ");
            }

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            Console.WriteLine("\n\nChanging the value at index 4 and printing in DESC:\nWith LINQ Method:");
            numbers.Select((n, index) => index == 4 ? 49 : n).OrderByDescending(n => n).ToList().ForEach(n => Console.Write($"{n}, "));
            //numbers.SetValue(49, 4);
            //numbers.OrderByDescending(n => n).ToList().ForEach(n => Console.Write($"{n}, "));

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            Console.WriteLine("\n\nAll the employees' FullName properties to the console only if their FirstName starts with a C OR an S...:\nWith LINQ Method:");
            var employeesCS = employees.Where(e => e.FirstName.StartsWith("c", StringComparison.OrdinalIgnoreCase) || e.FirstName.StartsWith("s", StringComparison.OrdinalIgnoreCase)).OrderBy(e => e.FirstName).ToList();
            employeesCS.ForEach(e => Console.WriteLine($"{e.FullName}"));

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine("\n\nAll the employees' FullName and Age who are over the age 26...:\nWith LINQ Method:");
            var employeesOver26 = employees.Where(e => e.Age > 26).OrderBy(e => e.Age).ThenBy(e => e.FirstName).ToList();
            employeesOver26.ForEach(e => Console.WriteLine($"Full Name: {e.FullName}, Age: {e.Age}"));

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine("\n\nPrint the Sum of the employees' YearsOfExperience:\nWith LINQ Method:");
            Console.WriteLine($"Sum of the employees' YearsOfExperience: {employees.Where(e => e.YearsOfExperience <= 10 && e.Age > 35).Sum(e => e.YearsOfExperience)}");

            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine("\n\nPrint the Average of the employees' YearsOfExperience:\nWith LINQ Method:");
            Console.WriteLine($"Average of the employees' YearsOfExperience: {Math.Round(employees.Where(e => e.YearsOfExperience <= 10 && e.Age > 35).Average(e => e.YearsOfExperience), 3)}");

            //TODO: Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("\n\nAdd an employee to the end of the list without using employees.Add():\nWith LINQ Method:");
            // employees.AddRange( new Employee("New", "Employee", 39, 6) );
            // employees.ToList().ForEach(e => Console.WriteLine(e.FullName));
            employees = employees.Append( new Employee("New", "Employee", 39, 6) ).ToList();
            // employees.ForEach(e => Console.WriteLine(e.FullName));

            Console.WriteLine();

            Console.ReadLine();

        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
