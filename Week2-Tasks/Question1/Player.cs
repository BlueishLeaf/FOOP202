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
        public Player(string name, DateTime dob)
        {
            Name = name;
            DOB = dob;
        }
        public override string ToString()
        {
            return String.Format("{0}, {1}",Name,DOB);
        }
    }
}
