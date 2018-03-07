using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sheet1
{
    class Program
    {
        static void Main(string[] args)
        {
            Question1();
            Question2();
            Question3();
            Question4();
            Question5();
            Question678();
            Question9();
            Console.Read();
        }

        static void Question1()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var outputNums = nums.Where(n => n > 5).OrderByDescending(n => n);
            //var outputNums = from num in nums
            //            where num > 5
            //            orderby num descending
            //            select num;
            foreach (int num in nums)
            {
                Console.WriteLine(num);
            }
        }

        static void Question2()
        {
            var files = new DirectoryInfo("C:\\Windows").GetFiles();
            var query = files.Where(f => f.Length > 10000).OrderBy(f => f.Length).ThenBy(f => f.Name).Select(f => new MyFileInfo { Name = f.Name, Length = f.Length, CreationTime = f.CreationTime });
            //var query = from item in files
            //            where item.Length > 10000
            //            orderby item.Length, item.Name
            //            select new MyFileInfo
            //            {
            //                Name = item.Name,
            //                Length = item.Length,
            //                CreationTime = item.CreationTime
            //            };
            foreach (var item in query)
            {
                Console.WriteLine("{0} \t {1} bytes, \t {2}", item.Name, item.Length, item.CreationTime);
            }
        }

        static void Question3()
        {
            var files = new DirectoryInfo("C:\\Windows").GetFiles();
            var query = files.Where(f => f.Length > 10000).OrderBy(f => f.Length).ThenBy(f => f.Name).Select(f => new { Name = f.Name, Length = f.Length, CreationTime = f.CreationTime });
            //var query = from item in files
            //            where item.Length > 10000
            //            orderby item.Length, item.Name
            //            select new
            //            {
            //                Name = item.Name,
            //                Length = item.Length,
            //                CreationTime = item.CreationTime
            //            };
        }

        static void Question4()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var query = nums.Select(n => (n * 2));
            //var query = from num in nums
            //            select num * 2;
            foreach (var num in query)
            {
                Console.WriteLine(num);
            }
        }

        static void Question5()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var query1 = nums.OrderByDescending(n => n);
            var query2 = query1.Where(n => n < 8);
            var query3 = query2.Select(n => (n * 2));
            //var query1 = from num in nums
            //         orderby num descending
            //         select num;
            //var query2 = from num in query1
            //         where num < 8
            //         select num;
            //var query3 = from num in query2
            //         select (num * 2);
            foreach (var num in query3)
            {
                Console.WriteLine(num);
            }
        }

        static void Question678()
        {
            string[] names = { "Mary", "Joseph", "Michael", "Sarah", "Margaret", "John" };
            var query = names.OrderBy(n => n).Where(n => n.StartsWith('M'));
            //var query = from name in names
            //        orderby name descending
            //        where name.StartsWith('M')
            //        select name;
            foreach (var name in query)
            {
                Console.WriteLine(name);
            }
        }

        static void Question9()
        {
            List<Customer> CustomerList = new List<Customer>
            {
                new Customer { Name = "Tommy", City = "Galway" },
                new Customer { Name = "Harry", City = "Dublin" },
                new Customer { Name = "Jane", City = "Dublin" },
                new Customer { Name = "Christopher", City = "Cork" },
                new Customer { Name = "Killian", City = "Sligo" }
            };
            var query = CustomerList.Where(c => c.City.Equals("Dublin")).Select(c=>c.Name);
            //var query = from customer in CustomerList
            //            where customer.City.Equals("Dublin")
            //            select customer.Name;
            foreach (var customer in query)
            {
                Console.WriteLine(customer);
            }
        }
    }
}
