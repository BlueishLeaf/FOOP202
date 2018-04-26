using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOP_Project
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public List<Event> Type { get; set; }
    }

    public class Event
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<Gift> PotentialGifts { get; set; }
    }

    public class Gift
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
