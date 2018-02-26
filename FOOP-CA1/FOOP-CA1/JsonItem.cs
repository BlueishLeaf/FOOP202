using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace FOOP_CA1
{
    // This class manages the deserialisation of the vehicles.json file
    using J = JsonPropertyAttribute;
    public class JsonItem
    {
        #region Properties
        // The following properties are tagged with 'J'
        // to flag them to be deserialised by the JSON deserialiser
        [J("Make")] public string Make { get; set; }
        [J("Model")] public string Model { get; set; }
        [J("Price")] public decimal Price { get; set; }
        [J("Year")] public int Year { get; set; }
        [J("Mileage")] public int Mileage { get; set; }
        [J("Colour")] public string Colour { get; set; }
        [J("ImagePath")] public string ImagePath { get; set; }
        [J("Description")] public string Description { get; set; }
        [J("BodyType")] public int? BodyType { get; set; }
        [J("BikeType")] public int? BikeType { get; set; }
        [J("VanType")] public int? VanType { get; set; }
        [J("WheelBase")] public int? WheelBase { get; set; }
        #endregion

        // JSON is passed in and deserialised into a list of JsonItems.
        // Uses a lamda expression
        public static List<JsonItem> DeserializeJson(string json) => JsonConvert.DeserializeObject<List<JsonItem>>(json);

        public static string SerializeJson(ObservableCollection<Vehicle> collection) => JsonConvert.SerializeObject(collection, Formatting.Indented);
    }
}
