using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOP_CA1
{
    class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public string Colour { get; set; }
        public int Mileage { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7}", Make, Model, Price, Year, Colour, Mileage, Description, Image);
        }
    }
    class Car : Vehicle
    {
        public string BodyType { get; set; }
        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}", Make, Model, Price, Year, Colour, Mileage, Description, Image, BodyType);
        }
    }
    class Motorcycle : Vehicle
    {
        public string Type { get; set; }
        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}", Make, Model, Price, Year, Colour, Mileage, Description, Image, Type);
        }
    }
    class Van : Vehicle
    {
        public string Wheelbase { get; set; }
        public string Type { get; set; }
        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", Make, Model, Price, Year, Colour, Mileage, Description, Image, Wheelbase, Type);
        }
    }
}
