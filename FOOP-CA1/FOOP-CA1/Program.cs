using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOP_CA1
{
    class Program
    {
        public List<Vehicle> CreateVehicles()
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            vehicleList.Add(new Car { Make = "Ford", Model = "Ford", Price = 100000, Year = 2010, Mileage = 50000, Description = "Ford", Colour = "Red", BodyType = "Body1" });
            vehicleList.Add(new Car { Make = "Ford", Model = "Ford", Price = 100000, Year = 2010, Mileage = 50000, Description = "Ford", Colour = "Red", BodyType = "Body1" });
            vehicleList.Add(new Car { Make = "Ford", Model = "Ford", Price = 100000, Year = 2010, Mileage = 50000, Description = "Ford", Colour = "Red", BodyType = "Body1" });
            vehicleList.Add(new Motorcycle { Make = "Ford", Model = "Ford", Price = 100000, Year = 2010, Mileage = 50000, Description = "Ford", Colour = "Red", Type = "Type1" });
            vehicleList.Add(new Motorcycle { Make = "Ford", Model = "Ford", Price = 100000, Year = 2010, Mileage = 50000, Description = "Ford", Colour = "Red", Type = "Type1" });
            vehicleList.Add(new Motorcycle { Make = "Ford", Model = "Ford", Price = 100000, Year = 2010, Mileage = 50000, Description = "Ford", Colour = "Red", Type = "Type1" });
            vehicleList.Add(new Van { Make = "Ford", Model = "Ford", Price = 100000, Year = 2010, Mileage = 50000, Description = "Ford", Colour = "Red", Type = "Type1", Wheelbase="Wheel1" });
            vehicleList.Add(new Van { Make = "Ford", Model = "Ford", Price = 100000, Year = 2010, Mileage = 50000, Description = "Ford", Colour = "Red", Type = "Type1", Wheelbase = "Wheel1" });
            vehicleList.Add(new Van { Make = "Ford", Model = "Ford", Price = 100000, Year = 2010, Mileage = 50000, Description = "Ford", Colour = "Red", Type = "Type1", Wheelbase = "Wheel1" });
            return vehicleList;
        }

        public List<Vehicle> DeleteItem(List<Vehicle> vehicleList, Vehicle selectedItem)
        {
            vehicleList.Remove(selectedItem);
            return vehicleList;
        }
    }
}
