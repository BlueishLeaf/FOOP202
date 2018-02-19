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
        public ObservableCollection<Vehicle> VehicleCollection { get; set; }
        public ObservableCollection<Vehicle> CreateVehicles()
        {
            //VehicleCollection = new ObservableCollection<Vehicle>
            //{
            //    new Car
            //    {
            //        Make = "Ford",
            //        Model = "Ford",
            //        Price = 100000,
            //        Year = 2010,
            //        Mileage = 50000,
            //        Description = "Ford",
            //        Colour = "Red",
            //        BodyType = BodyType.Convertible
            //    },
            //    new Car
            //    {
            //        Make = "Ford",
            //        Model = "Ford",
            //        Price = 100000,
            //        Year = 2010,
            //        Mileage = 50000,
            //        Description = "Ford",
            //        Colour = "Red",
            //        BodyType = BodyType.Coupe
            //    },
            //    new Car
            //    {
            //        Make = "Ford",
            //        Model = "Ford",
            //        Price = 100000,
            //        Year = 2010,
            //        Mileage = 50000,
            //        Description = "Ford",
            //        Colour = "Red",
            //        BodyType = BodyType.Estate
            //    },
            //    new Motorcycle
            //    {
            //        Make = "Ford",
            //        Model = "Ford",
            //        Price = 100000,
            //        Year = 2010,
            //        Mileage = 50000,
            //        Description = "Ford",
            //        Colour = "Red",
            //        Type = BikeType.Bike
            //    },
            //    new Motorcycle
            //    {
            //        Make = "Ford",
            //        Model = "Ford",
            //        Price = 100000,
            //        Year = 2010,
            //        Mileage = 50000,
            //        Description = "Ford",
            //        Colour = "Red",
            //        Type = BikeType.Commuter
            //    },
            //    new Motorcycle
            //    {
            //        Make = "Ford",
            //        Model = "Ford",
            //        Price = 100000,
            //        Year = 2010,
            //        Mileage = 50000,
            //        Description = "Ford",
            //        Colour = "Red",
            //        Type = BikeType.Scooter
            //    },
            //    new Van
            //    {
            //        Make = "Ford",
            //        Model = "Ford",
            //        Price = 100000,
            //        Year = 2010,
            //        Mileage = 50000,
            //        Description = "Ford",
            //        Colour = "Red",
            //        Type = VanType.CombiVan,
            //        Wheelbase = Wheelbase.Long
            //    },
            //    new Van
            //    {
            //        Make = "Ford",
            //        Model = "Ford",
            //        Price = 100000,
            //        Year = 2010,
            //        Mileage = 50000,
            //        Description = "Ford",
            //        Colour = "Red",
            //        Type = VanType.Dropside,
            //        Wheelbase = Wheelbase.Medium
            //    },
            //    new Van
            //    {
            //        Make = "Ford",
            //        Model = "Ford",
            //        Price = 100000,
            //        Year = 2010,
            //        Mileage = 50000,
            //        Description = "Ford",
            //        Colour = "Red",
            //        Type = VanType.PanelVan,
            //        Wheelbase = Wheelbase.Short
            //    }
            //};
            VehicleCollection = ReadJSON();
            return VehicleCollection;
        }

        public ObservableCollection<Vehicle> DeleteItem(Vehicle selectedItem)
        {
            VehicleCollection.Remove(selectedItem);
            return VehicleCollection;
        }

        public ObservableCollection<Vehicle> ReadJSON()
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
    }
}
