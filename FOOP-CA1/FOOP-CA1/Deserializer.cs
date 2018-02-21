using System.Collections.Generic;
using Newtonsoft.Json;

namespace FOOP_CA1
{
    using J = Newtonsoft.Json.JsonPropertyAttribute;
    public class JsonVehicles
    {
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

        public static List<JsonVehicles> DeserializeJson(string json) => JsonConvert.DeserializeObject<List<JsonVehicles>>(json);
    }
}
