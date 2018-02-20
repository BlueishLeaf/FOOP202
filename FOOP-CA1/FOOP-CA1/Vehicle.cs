using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
        public BitmapImage GenericImage { get; set; }
    }

    internal class Car : Vehicle
    {
        public BodyType BodyType { get; set; }

        public Car()
        {
            GenericImage = new BitmapImage(new Uri(@"\assets\icons\caricon.png", UriKind.Relative));
        }
    }

    internal class Motorcycle : Vehicle
    {
        public BikeType Type { get; set; }
        public Motorcycle()
        {
            GenericImage = new BitmapImage(new Uri(@"\assets\icons\bikeicon.png", UriKind.Relative));
        }
    }

    internal class Van : Vehicle
    {
        public Wheelbase Wheelbase { get; set; }
        public VanType Type { get; set; }
        public Van()
        {
            GenericImage = new BitmapImage(new Uri(@"\assets\icons\vanicon.png", UriKind.Relative));
        }
    }
}
