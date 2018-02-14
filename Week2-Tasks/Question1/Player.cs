using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    class Player
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Category { get; set; }
        public Player(string name, DateTime dob)
        {
            Name = name;
            DOB = dob;
            int age = DateTime.Now.Year - DOB.Year;
            Console.WriteLine(age);
            if (age <= 10)
            {
                Category = "(UNDER 10)";
            }
            else if (age <= 12)
            {
                Category = "(UNDER 12)";
            }
            else if (age <= 14)
            {
                Category = "(UNDER 14)";
            }
            else if (age <= 16)
            {
                Category = "(UNDER 16)";
            }
            else if (age < 18)
            {
                Category = "(UNDER 18)";
            }
            else if (age == 18)
            {
                Category = "Senior";
            }
        }
        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}",Name,DOB.ToShortDateString(),Category);
        }
    }
}
