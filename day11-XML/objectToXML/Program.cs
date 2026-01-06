using System;
using System.Xml.Serialization;
using System.IO;
// Define the Driver class with properties to be serialized
public class Driver
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Team { get; set; }
    public string[]? Position { get; set; }
    public List<string>? Achievements { get; set; }

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

        XmlSerializer serializer = new XmlSerializer(typeof(Driver)); // Initialize the XmlSerializer for the Driver type

        using (StringWriter writer = new StringWriter()) // Use StringWriter to capture the XML output
        {
            serializer.Serialize(writer, driver); // Serialize the Driver object to XML
            string xmlOutput = writer.ToString(); // Get the XML string from the StringWriter
            Console.WriteLine(xmlOutput);
        }
    }
}