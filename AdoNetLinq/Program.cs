using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
class Program
{
    static void View()
    {
        string cs = "Server=localhost\\SQLEXPRESS;Database=TrainingDB;Trusted_Connection=True;TrustServerCertificate=True;";
        using var con = new SqlConnection(cs);
        using var cmd = new SqlCommand("SELECT StudentId, FullName, City, Marks FROM Students WHERE IsActive = 1", con);
        con.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            string city = reader.GetString(2);
            int marks = reader.GetInt32(3);
            Console.WriteLine($"{id} | {name} | {city} | {marks}");
        }
    }
    static void ActiveInactive()
    {
        string cs = "Server=localhost\\SQLEXPRESS;Database=TrainingDB;Trusted_Connection=True;TrustServerCertificate=True;";
        using var con = new SqlConnection(cs);
        using var da = new SqlDataAdapter("SELECT FullName, IsActive FROM Students", con);
        DataTable students = new DataTable();
        da.Fill(students);
        var rows = students.AsEnumerable();
        var activeNames = rows
            .Where(r => r.Field<bool>("IsActive") == true)
            .Select(r => r.Field<string>("FullName"))
            .ToList();
        activeNames.ForEach(Console.WriteLine);
    }
    static void Toppers()
    {
        string cs = "Server=localhost\\SQLEXPRESS;Database=TrainingDB;Trusted_Connection=True;TrustServerCertificate=True;";
        using var con = new SqlConnection(cs);
        using var da = new SqlDataAdapter("SELECT StudentId, FullName, Marks, IsActive FROM Students",con);
        DataTable students = new DataTable();
        da.Fill(students);
        var toppers = students.AsEnumerable()
            .Where(r => r.Field<int>("Marks") >= 80)
            .Select(r => new
            {
                Id = r.Field<int>("StudentId"),
                Name = r.Field<string>("FullName"),
                Marks = r.Field<int>("Marks")
            })
            .ToList();
        foreach (var s in toppers)
            Console.WriteLine($"{s.Id} | {s.Name} | {s.Marks}");
    }
    static void BelowAverage()
    {
        string cs = "Server=localhost\\SQLEXPRESS;Database=TrainingDB;Trusted_Connection=True;TrustServerCertificate=True;";
        using var con = new SqlConnection(cs);
        using var da = new SqlDataAdapter("SELECT StudentId, FullName, Marks, IsActive FROM Students",con);
        DataTable students = new DataTable();
        da.Fill(students);
        var belowAverage = students.AsEnumerable()
                            .Where(r => r.Field<int>("Marks") <70)
                            .Select(r => new
                            {
                                Id = r.Field<int>("StudentId"),
                                Name = r.Field<string>("FullName"),
                                Marks = r.Field<int>("Marks")
                            }).ToList();
        foreach(var x in belowAverage)
        {
            Console.WriteLine($"{x.Id} | {x.Name} | {x.Marks}");
        }
    }
    static void Main()
    {
        Console.WriteLine("1. View");
        Console.WriteLine("2. ActiveInactive");
        Console.WriteLine("3. Toppers");
        Console.WriteLine("4. Below Average");
        int ch = int.Parse(Console.ReadLine());
        if (ch == 1) View();
        else if (ch == 2) ActiveInactive();
        else if (ch == 3) Toppers();
        else if (ch == 4) BelowAverage();
    }
}