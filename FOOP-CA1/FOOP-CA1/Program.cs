using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;

namespace FOOP_CA1
{
    internal class Program
    {
        public string[] ComboStrings = {"Make", "Model","Price","Mileage"};
        public ObservableCollection<Vehicle> VehicleCollection { get; set; }
        public ObservableCollection<Vehicle> CreateVehicles()
        {
            VehicleCollection = new ObservableCollection<Vehicle>
            {
                new Car
                {
                    Make = "Renault",
                    Model = "Captur",
                    Price = 75866,
                    Year = 2010,
                    Mileage = 40215,
                    Description = "Sample",
                    Colour = "green",
                    BodyType = BodyType.Convertible,
                    ImagePath = "/assets/images/c1.png"
                },
                new Motorcycle
                {
                    Make = "Mercedes",
                    Model = "Tourismo",
                    Price = 48818,
                    Year = 2004,
                    Mileage = 56145,
                    Description = "Sample",
                    Colour = "white",
                    Type = BikeType.Bike,
                    ImagePath = "/assets/images/b1.png"
                },
                new Van
                {
                    Make = "Renault",
                    Model = "Magnum",
                    Price = 84168,
                    Year = 2016,
                    Mileage = 58770,
                    Description = "Sample",
                    Colour = "orange",
                    Type = VanType.CombiVan,
                    Wheelbase = Wheelbase.Long,
                    ImagePath = "/assets/images/v1.png"
                }
            };
            return VehicleCollection;
        }

        public ObservableCollection<Vehicle> DeleteItem(Vehicle selectedItem)
        {
            VehicleCollection.Remove(selectedItem);
            return VehicleCollection;
        }

        public ObservableCollection<Vehicle> ReadJson()
        {
            using (var reader = new StreamReader("vehicles.json"))
            {
                var vehicles = JsonVehicles.DeserializeJson(reader.ReadToEnd());
                foreach (var vehicle in vehicles)
                {
                    if (vehicle.BodyType != null)
                    {
                        VehicleCollection.Add(new Car{ Make = vehicle.Make, Model = vehicle.Model, Price = vehicle.Price, Year = vehicle.Year, Mileage = vehicle.Mileage, Description = vehicle.Description,Colour = vehicle.Colour, ImagePath = vehicle.ImagePath, BodyType = (BodyType) vehicle.BodyType});
                    }
                    else if (vehicle.BikeType != null)
                    {
                        VehicleCollection.Add(new Motorcycle{ Make = vehicle.Make, Model = vehicle.Model, Price = vehicle.Price, Year = vehicle.Year, Mileage = vehicle.Mileage, Description = vehicle.Description, Colour = vehicle.Colour, ImagePath = vehicle.ImagePath, Type = (BikeType)vehicle.BikeType });
                    }
                    else if (vehicle.VanType != null && vehicle.WheelBase !=null)
                    {
                        VehicleCollection.Add(new Van{ Make = vehicle.Make, Model = vehicle.Model, Price = vehicle.Price, Year = vehicle.Year, Mileage = vehicle.Mileage, Description = vehicle.Description, Colour = vehicle.Colour, ImagePath = vehicle.ImagePath, Type = (VanType)vehicle.VanType, Wheelbase = (Wheelbase) vehicle.WheelBase});
                    }
                }
            }
            return VehicleCollection;
        }

        public void WriteJson()
        {
            using (var writer = new StreamWriter("vehicles.json"))
            {
                writer.Write(JsonConvert.SerializeObject(VehicleCollection, Formatting.Indented));
            }
        }

        public IOrderedEnumerable<Vehicle> SortBy(string arg)
        {
            switch (arg)
            {
                case "Make":
                    return VehicleCollection.OrderBy(a => a.Make);
                case "Model":
                    return VehicleCollection.OrderBy(a => a.Model);
                case "Price":
                    return VehicleCollection.OrderBy(a => a.Price);
                case "Mileage":
                    return VehicleCollection.OrderBy(a => a.Mileage);
                default:
                    return null;
            }
        }

        public ObservableCollection<Vehicle> FilterBy(string arg)
        {
            var filteredCollection = new ObservableCollection<Vehicle>();
            switch (arg)
            {
                case "All":
                    return VehicleCollection;
                case "Cars":
                    foreach (var vehicle in VehicleCollection)
                    {
                        if (vehicle.GetType() == typeof(Car))
                        {
                            filteredCollection.Add(vehicle);
                        }
                    }
                    return filteredCollection;
                case "Bikes":
                    foreach (var vehicle in VehicleCollection)
                    {
                        if (vehicle.GetType() == typeof(Motorcycle))
                        {
                            filteredCollection.Add(vehicle);
                        }
                    }
                    return filteredCollection;
                case "Vans":
                    foreach (var vehicle in VehicleCollection)
                    {
                        if (vehicle.GetType() == typeof(Van))
                        {
                            filteredCollection.Add(vehicle);
                        }
                    }
                    return filteredCollection;
                default:
                    return filteredCollection;
            }
        }

        public BitmapImage GetImage(Vehicle selectedVehicle)
        {
            return new BitmapImage(new Uri(selectedVehicle.ImagePath, UriKind.Relative));
        }
    }
}
