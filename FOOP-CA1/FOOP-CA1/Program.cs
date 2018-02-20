using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FOOP_CA1
{
    class Program
    {
        public string[] ComboStrings = {"Make", "Model","Price","Mileage"};
        public ObservableCollection<Vehicle> VehicleCollection { get; set; }
        public ObservableCollection<Vehicle> CreateVehicles()
        {
            VehicleCollection = new ObservableCollection<Vehicle>
            {
                new Car
                {
                    Make = "Ford",
                    Model = "Ford",
                    Price = 100000,
                    Year = 2010,
                    Mileage = 50000,
                    Description = "Ford",
                    Colour = "Red",
                    BodyType = BodyType.Convertible
                },
                new Motorcycle
                {
                    Make = "Audi",
                    Model = "Ford",
                    Price = 100000,
                    Year = 2010,
                    Mileage = 50000,
                    Description = "Ford",
                    Colour = "Red",
                    Type = BikeType.Bike
                },
                new Van
                {
                    Make = "Renault",
                    Model = "Ford",
                    Price = 100000,
                    Year = 2010,
                    Mileage = 50000,
                    Description = "Ford",
                    Colour = "Red",
                    Type = VanType.CombiVan,
                    Wheelbase = Wheelbase.Long
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
            using (StreamReader reader = new StreamReader("vehicles.json"))
            {
                List<Vehicle> vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(reader.ReadToEnd());
                foreach (Vehicle vehicle in vehicles)
                {
                    VehicleCollection.Add(vehicle);
                }
            }
            return VehicleCollection;
        }

        public void WriteJson()
        {
            using (StreamWriter writer = new StreamWriter("vehicles.json"))
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
            ObservableCollection<Vehicle> filteredCollection = new ObservableCollection<Vehicle>();
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
    }
}
