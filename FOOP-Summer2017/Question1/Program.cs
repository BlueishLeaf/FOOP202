using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    class Program
    {
        List<Employee> employees = new List<Employee>();
        public List<Employee> GetEmployees()
        {
            employees.Add(new PartTimeEmployee() { FirstName = "Tom", LastName = "Jones", PPS = "P87654321", HourlyRate = 10, HoursWorked = 100 });
            employees.Add(new PartTimeEmployee() { FirstName = "Mary", LastName = "McKenna", PPS = "P87654322", HourlyRate = 12, HoursWorked = 160 });
            employees.Add(new PartTimeEmployee() { FirstName = "Sally", LastName = "Purcell", PPS = "P87654323", HourlyRate = 9, HoursWorked = 60 });
            employees.Add(new PartTimeEmployee() { FirstName = "Michael", LastName = "Egan", PPS = "P87654324", HourlyRate = 15, HoursWorked = 120 });
            employees.Add(new PartTimeEmployee() { FirstName = "Sue", LastName = "Quinn", PPS = "P87654325", HourlyRate = 20, HoursWorked = 80 });
            employees.Add(new FullTimeEmployee() { FirstName = "Mick", LastName = "Smith", PPS = "F12345678", Salary = 25000, ReviewDate = DateTime.Now.AddMonths(12)});
            employees.Add(new FullTimeEmployee() { FirstName = "Joe", LastName = "Agnew", PPS = "F12345678", Salary = 25000, ReviewDate = DateTime.Now.AddMonths(6) });
            employees.Add(new FullTimeEmployee() { FirstName = "Sarah", LastName = "Ryan", PPS = "F12345678", Salary = 25000, ReviewDate = DateTime.Now.AddMonths(3) });
            employees.Add(new FullTimeEmployee() { FirstName = "Barry", LastName = "McMahon", PPS = "F12345678", Salary = 25000, ReviewDate = DateTime.Now.AddMonths(12) });
            employees.Add(new FullTimeEmployee() { FirstName = "Linda", LastName = "Tormey", PPS = "F12345678", Salary = 25000, ReviewDate = DateTime.Now.AddMonths(6) });
            return employees;
        }

    }
}
