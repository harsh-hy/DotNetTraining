using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
// Define the Driver class with properties to be serialized
public class Driver
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Team { get; set; }
    public string[]? Position { get; set; }
    public List<string>? Achievements { get; set; }
    // conversions will work for the basic data types(mentioned above) but not for Dictionary or complex types like DateTime, TimeSpan etc.
}
// Main program to serialize the Driver object to XML
class Program
{
    static void Main(string[] args)
    {
        Driver driver = new Driver // Create a Driver object with sample data
        {
            Id = 3,
            Name = "Max Verstappen",
            Age = 28,
            Team = "Red Bull Racing RBPT",
            Position = new string[] { "P1", "P1", "P2", "P1", "P1" },
            Achievements = new List<string>
            {
                "Youngest driver to score points in F1",
                "Youngest driver to win a Grand Prix",
                "2021 Formula 1 World Champion",
                "2022 Formula 1 World Champion",
                "2023 Formula 1 World Champion",
                "2024 Formula 1 World Champion"
            }
        };
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true // Enable pretty-printing for better readability
        };
        string jsonString = JsonSerializer.Serialize(driver, options); // Serialize the Driver object to JSON
        Console.WriteLine(jsonString); // Output the JSON string to the console
    }
}