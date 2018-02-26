using System;
using System.Windows.Media.Imaging;

namespace FOOP_CA1
{
    #region Enums
    // Enumerables for the extra properties that classes inherited from Vehicle have
    public enum BodyType
    {
        Convertible,
        Hatchback,
        Coupe,
        Estate,
        Mpv,
        Suv,
        Saloon,
        Unlisted
    }
    public enum BikeType
    {
        Scooter,
        Trail,
        Bike,
        Sports,
        Commuter,
        Tourer
    }
    public enum VanType
    {
        CombiVan,
        Dropside,
        PanelVan,
        Pickup,
        Tipper,
        Unlisted
    }
    public enum Wheelbase
    {
        Short,
        Medium,
        Long,
        Unlisted
    }
    #endregion

    // This class contains all the methods and properties of a vehicle as well as its children
    public class Vehicle
    {
        #region Vehicle Properties
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public string Colour { get; set; }
        public int Mileage { get; set; }
        public string Description { get; set; }
        // GenericImage is the icon representing Car, a Motorcycle, or a Van
        public BitmapImage GenericImage { get; set; }
        public string ImagePath { get; set; }

        #endregion

        // Creates a BitmapImage from the ImagePath and returns it
        public BitmapImage GetImage()
        {
            return new BitmapImage(new Uri(ImagePath, UriKind.Relative));
        }
    }

    #region Children
    // The following inherited classes are the types of vehicles used in the program
    internal class Car : Vehicle
    {
        public BodyType BodyType { get; set; }
        
        // The constructor assigns the car icon to the GenericImage property
        public Car() => GenericImage = new BitmapImage(new Uri(@"\assets\icons\caricon.png", UriKind.Relative));

        // Returns the description of the vehicle along with its body type as a string
        public override string ToString() => $"{Description},{BodyType}";
    }

    internal class Motorcycle : Vehicle
    {
        public BikeType Type { get; set; }

        // The constructor assigns the bike icon to the GenericImage property
        public Motorcycle() => GenericImage = new BitmapImage(new Uri(@"\assets\icons\bikeicon.png", UriKind.Relative));

        // Returns the description of the vehicle along with its bike type as a string
        public override string ToString() => $"{Description},{Type}";
    }

    internal class Van : Vehicle
    {
        public Wheelbase Wheelbase { get; set; }
        public VanType Type { get; set; }

        // The constructor assigns the van icon to the GenericImage property
        public Van() => GenericImage = new BitmapImage(new Uri(@"\assets\icons\vanicon.png", UriKind.Relative));

        // Returns the description of the vehicle along with its van type and wheelbase as a string
        public override string ToString() => $"{Description},{Type},{Wheelbase}";
    }
    #endregion

}