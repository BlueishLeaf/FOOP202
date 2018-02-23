﻿using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace FOOP_CA1
{
    // This class is the control class of the program. It handles
    // most of the non-UI logic in the application
    public class Program
    {
        #region Properties
        // The options available in the "sort by" combo box
        public string[] ComboStrings = { "Make", "Model", "Price", "Mileage" };
        // The dynamic collection of vehicles used throughout the program
        public ObservableCollection<Vehicle> VehicleCollection { get; set; }
        public JsonSerializerSettings SerializerSettings { get => serializerSettings; set => serializerSettings = value; }
        #endregion

        #region Vehicle Creation/Deletion
        // The sole purpose of the constructor is to create 3 sample
        // vehicles when the application loads. The collection is populated
        // further when the JSON is loaded
        public Program() => VehicleCollection = new ObservableCollection<Vehicle>
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

        // Removes the selected item passed into the method
        public void DeleteItem(Vehicle selectedItem) => VehicleCollection.Remove(selectedItem);
        #endregion

        #region JSON
        // Reads in the JSON from a file and passes the string to the deserializer class.
        // Loops through the JsonItem list and checks what nullable properties are not null
        // to determine the Item's vehicle type, then creates an instance of that class using the Item's information
        public ObservableCollection<Vehicle> ParseJsonItems()
        {
            var json = SelectFile();
            var vehicles = JsonItem.DeserializeJson(json);
            foreach (var vehicle in vehicles)
                if (vehicle.BodyType != null)
                    VehicleCollection.Add(new Car
                    {
                        Make = vehicle.Make,
                        Model = vehicle.Model,
                        Price = vehicle.Price,
                        Year = vehicle.Year,
                        Mileage = vehicle.Mileage,
                        Description = vehicle.Description,
                        Colour = vehicle.Colour,
                        ImagePath = vehicle.ImagePath,
                        BodyType = (BodyType)vehicle.BodyType
                    });
                else if (vehicle.BikeType != null)
                    VehicleCollection.Add(new Motorcycle
                    {
                        Make = vehicle.Make,
                        Model = vehicle.Model,
                        Price = vehicle.Price,
                        Year = vehicle.Year,
                        Mileage = vehicle.Mileage,
                        Description = vehicle.Description,
                        Colour = vehicle.Colour,
                        ImagePath = vehicle.ImagePath,
                        Type = (BikeType)vehicle.BikeType
                    });
                else if (vehicle.VanType != null && vehicle.WheelBase != null)
                    VehicleCollection.Add(new Van
                    {
                        Make = vehicle.Make,
                        Model = vehicle.Model,
                        Price = vehicle.Price,
                        Year = vehicle.Year,
                        Mileage = vehicle.Mileage,
                        Description = vehicle.Description,
                        Colour = vehicle.Colour,
                        ImagePath = vehicle.ImagePath,
                        Type = (VanType)vehicle.VanType,
                        Wheelbase = (Wheelbase)vehicle.WheelBase
                    });
            return VehicleCollection;
        }

        // Simple method to write the current collection of vehicles to a file in the debug
        // folder names "savedVehicles.json"
        public void SaveToJson()
        {
            using (var writer = new StreamWriter("savedVehicles.json"))
                writer.Write(JsonConvert.SerializeObject(VehicleCollection, Formatting.Indented));
        }
        #endregion

        #region Sorting/Filtering
        // Sorts the collection of vehicles by whatever option the user chooses in
        // the "sort by" combo box. Uses a simple LINQ expression to sort
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

        // Filters the collection of vehicles by whatever radio button the user checks.
        // Compares each vehicle to the desired type and returns a filtered collection
        public ObservableCollection<Vehicle> FilterBy(string arg)
        {
            var filteredCollection = new ObservableCollection<Vehicle>();
            switch (arg)
            {
                case "All":
                    return VehicleCollection;
                case "Cars":
                    foreach (var vehicle in VehicleCollection)
                        if (vehicle.GetType() == typeof(Car))
                            filteredCollection.Add(vehicle);
                    return filteredCollection;
                case "Bikes":
                    foreach (var vehicle in VehicleCollection)
                        if (vehicle.GetType() == typeof(Motorcycle))
                            filteredCollection.Add(vehicle);
                    return filteredCollection;
                case "Vans":
                    foreach (var vehicle in VehicleCollection)
                        if (vehicle.GetType() == typeof(Van))
                            filteredCollection.Add(vehicle);
                    return filteredCollection;
                default:
                    return filteredCollection;
            }
        }
        #endregion

        #region Adding/Editing Vehicles
        public void AddVehicle(MainWindow main)
        {
            //var addVehicle = new AddVehicle { Owner = main };
            //addVehicle.ShowDialog();
        }

        public void EditVehicle(MainWindow main, Vehicle selectedVehicle)
        {
            var editVehicle = new EditVehicle(selectedVehicle) { Owner = main };
            editVehicle.ShowDialog();
        }
        #endregion

        // Opens up a file explorer for the user to select either a json file or an image depending
        // on the argument. The explorer is filtered so that only files of a suitable type can be selected
        public string SelectFile()
        {
            var openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = "Json files (*.json)|*.json"
            };
            return openFileDialog.ShowDialog() == true ? File.ReadAllText(openFileDialog.FileName) : null;
        }

        private JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.All
        };

        public string SelectImage()
        {
            var openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg"
            };
            if (openFileDialog.ShowDialog() == true)
                File.Copy(openFileDialog.FileName, Path.Combine(GetImageDirectory() + openFileDialog.SafeFileName), true);
            return "/assets/images/" + openFileDialog.SafeFileName;
        }

        private static string GetImageDirectory()
        {
            var currentDir = Directory.GetCurrentDirectory();
            var parent = Directory.GetParent(currentDir);
            var grandParent = Directory.GetParent(parent.FullName);
            var imageDirectory = grandParent + "/assets/images/";
            return imageDirectory;
        }

        public void SaveDetails(Vehicle newVehicle)
        {
            VehicleCollection.Remove(newVehicle);
            VehicleCollection.Add(newVehicle);
        }

    }
}