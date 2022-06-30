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
            //TODO: Print the Sum of numbers
            Console.WriteLine($"The sum of numbers is {numbers.Sum()}\n");

            //TODO: Print the Average of numbers
            Console.WriteLine($"The average of numbers is {numbers.Average()}\n");

            //TODO: Order numbers in ascending order and print to the console
            var ascOrder = numbers.OrderBy(x => x).ToList();
            Console.WriteLine("Below is the numbers list in ascending order:");
            ascOrder.ForEach(Console.WriteLine);
            Console.WriteLine();

            //TODO: Order numbers in decsending order and print to the console
            var descOrder = numbers.OrderByDescending(x => x).ToList();
            Console.WriteLine("Below is the numbers list in descending order:");
            descOrder.ForEach(Console.WriteLine);
            Console.WriteLine();

            //TODO: Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(num => num > 6).ToList();
            Console.WriteLine("Below is the list where entries are greater than six:");
            greaterThanSix.ForEach(Console.WriteLine);
            Console.WriteLine();

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Below are the first four entries in ascending order:");
            foreach(var number in descOrder.Take(4))
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();

            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("Below is the number list in descending order where the fourth entry is my age (24)");
            numbers.SetValue(24, 4);
            numbers.OrderByDescending(x => x).ToList().ForEach(Console.WriteLine);
            descOrder.ForEach(Console.WriteLine);
            Console.WriteLine();

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in acesnding order by FirstName.
            Console.WriteLine("Below are all employees whos names begin with an 's' or a 'c'");
            var filteredEmp = employees.Where(person => person.FirstName.ToLower().StartsWith('c') || person.FirstName.ToLower()[0] == 's').OrderBy(person => person.FirstName); ;
            foreach (var person in filteredEmp)
            {
                Console.WriteLine(person.FullName);
            }
            Console.WriteLine();

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Below are all employees older than 26, ordered by age, then alphabetically:");
            var twentySix = employees.Where(x => x.Age > 26).OrderByDescending(x => x.Age).ThenBy(x => x.FirstName);
            foreach (var person in twentySix)
            {
                Console.WriteLine($"Name: {person.FullName}, Age: {person.Age}");
            }
            Console.WriteLine();

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35
            var sumAndYOE = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            Console.WriteLine($"Total YOE: {sumAndYOE.Sum(x => x.YearsOfExperience)}");
            Console.WriteLine($"Avg YOE: {sumAndYOE.Average(x => x.YearsOfExperience)}");
            Console.WriteLine();

            //TODO: Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("Adding myself to the end of the employees list:");
            employees = employees.Append(new Employee("Michael", "Maragos", 24, 5)).ToList();
            employees.ForEach(x => Console.WriteLine(x.FullName));

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
