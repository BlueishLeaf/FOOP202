﻿using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Microsoft.Win32;

namespace FOOP_CA1
{
    // NOTE: When loading the json, select the file "samplevehicles.json" in the root directory
    // and make sure the nuget packages installed (one for the json, the other is for the colour picker)
    // This class is the control class of the program. It handles
    // most of the non-UI logic in the application
    public class Program
    {
        #region Properties
        // The options available in the "sort by" combo box
        public string[] ComboStrings = { "Colour", "Make", "Model", "Price", "Mileage" };
        // The dynamic collection of vehicles used throughout the program
        public ObservableCollection<Vehicle> VehicleCollection { get; set; }

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
        // Must be viewing all vehicles to remove an item(i.e. do not sort, filtering is fine)
        public void DeleteItem(Vehicle selectedItem) => VehicleCollection.Remove(selectedItem);
        #endregion

        #region JSON
        // Opens up a file explorer for the user to select either a json file or an image depending
        // on the argument. The explorer is filtered so that only files of a suitable type can be selected
        public string SelectJson()
        {
            var openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = "Json files (*.json)|*.json"
            };
            return openFileDialog.ShowDialog() == true ? File.ReadAllText(openFileDialog.FileName) : null;
        }

        // Reads in the JSON from a file and passes the string to the deserializer class.
        // Loops through the JsonItem list and checks what nullable properties are not null
        // to determine the Item's vehicle type, then creates an instance of that class using the Item's information
        public ObservableCollection<Vehicle> ParseJsonItems()
        {
            var vehicles = JsonItem.DeserializeJson(SelectJson());
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

        // Opens file saving dialog. Serializes json when user chooses where to save
        public void SaveToJson()
        {
            var saveFileDialog = new SaveFileDialog
            {
                FileName = "Vehicle Data",
                Filter = "Json files (*.json)|*.json",
                DefaultExt = ".json"
            };

            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, JsonItem.SerializeJson(VehicleCollection));
        }
        #endregion

        #region Sorting/Filtering
        // Sorts the collection of vehicles by whatever option the user chooses in
        // the "sort by" combo box. Uses a simple LINQ expression to sort
        public IOrderedEnumerable<Vehicle> SortBy(string arg)
        {
            switch (arg)
            {
                case "Colour":
                    return VehicleCollection.OrderBy(a => a.Colour);
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
        // Creates a new EditVehicle window but passes in null, indicating that this vehicle should be
        // set up as a new one
        public void AddVehicle(MainWindow main)
        {
            var addVehicle = new EditVehicle { Owner = main };
            addVehicle.ShowDialog();
        }

        // Creates a new EditVehicle window and passes in the selected vehicle, allowing the EditWindow instance
        // to have access to its data
        public void EditVehicle(MainWindow main, Vehicle selectedVehicle)
        {
            var editVehicle = new EditVehicle(selectedVehicle) { Owner = main };
            editVehicle.ShowDialog();
            // Removes the edited vehicle if changes were saved
            if (editVehicle.NewVehicle != selectedVehicle)
                VehicleCollection.Remove(selectedVehicle);
        }

        // Called from within the EditVehicle window. Opens an OpenFileDialog and lets the user
        // choose an image.
        // *NB* please choose an image from the /assets/images folder as they are the only images marked as resources
        public string SelectImage()
        {
            var openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg"
            };
            if (openFileDialog.ShowDialog() == true)
                return "/assets/images/" + openFileDialog.SafeFileName;
            return null;
        }

        // Adds the new/edited vehicle to the main vehicle collection
        public void SaveDetails(Vehicle newVehicle) => VehicleCollection.Add(newVehicle);
        #endregion


    }
}