using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOP_CA1
{
    public enum BodyType {Convertible,Hatchback,Coupe,Estate,Mpv,Suv,Saloon,Unlisted}
    public enum BikeType { Scooter, Trail, Bike, Sports, Commuter, Tourer }
    public enum VanType { CombiVan, Dropside, PanelVan, Pickup, Tipper, Unlisted }
    public enum Wheelbase { Short, Medium, Long, Unlisted }

    internal class Vehicle
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

    internal class Car : Vehicle
    {
        public BodyType BodyType { get; set; }
        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}", Make, Model, Price, Year, Colour, Mileage, Description, Image, BodyType);
        }
    }

    internal class Motorcycle : Vehicle
    {
        public BikeType Type { get; set; }
        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}", Make, Model, Price, Year, Colour, Mileage, Description, Image, Type);
        }
    }

    internal class Van : Vehicle
    {
        public Wheelbase Wheelbase { get; set; }
        public VanType Type { get; set; }
        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", Make, Model, Price, Year, Colour, Mileage, Description, Image, Wheelbase, Type);
        }
    }
}
