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
                    Make = "Ford",
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
                    Make = "Ford",
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

        public void SortBy(string arg)
        {
            switch (arg)
            {
                case "Make":

                    break;
                case "Model":
                    break;
                case "Price":
                    break;
                case "Mileage":
                    break;
            }
        }
    }
}
