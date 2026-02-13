using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Data.SqlClient;
class Program
{
    static void InsertData()
    {
        string cs = "Server=localhost\\SQLEXPRESS;Database=TrainingDB;Trusted_Connection=True;TrustServerCertificate=True;";

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Dept: ");
        string dept = Console.ReadLine();

        Console.Write("Salary: ");
        decimal salary = decimal.Parse(Console.ReadLine());

        string sql = "INSERT INTO Employees(FullName,Department,Salary) VALUES(@n,@d,@s)";

        using (var con = new SqlConnection(cs))
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@n", name);
            cmd.Parameters.AddWithValue("@d", dept);
            cmd.Parameters.AddWithValue("@s", salary);

            con.Open();
            int rows = cmd.ExecuteNonQuery();

            Console.WriteLine("Rows inserted: " + rows);
        }
    }
    static void ShowData()
    {
        string cs = "Server=localhost\\SQLEXPRESS;Database=TrainingDB;Trusted_Connection=True;TrustServerCertificate=True;";
        string sql = "SELECT * FROM Employees";

        using (var con = new SqlConnection(cs))
        using (var cmd = new SqlCommand(sql, con))
        {
            con.Open();

            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    Console.WriteLine(r["EmployeeId"] + " " + r["FullName"]);
                }
            }
        }
    }
    static void UpdateSalary()
    {
        string cs = "Server=localhost\\SQLEXPRESS;Database=TrainingDB;Trusted_Connection=True;TrustServerCertificate=True;";

        Console.Write("Employee Id: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("New Salary: ");
        decimal salary = decimal.Parse(Console.ReadLine());

        string sql = "UPDATE Employees SET Salary=@s WHERE EmployeeId=@id";

        using (var con = new SqlConnection(cs))
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@s", salary);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            int rows = cmd.ExecuteNonQuery();

            Console.WriteLine("Updated rows: " + rows);
        }
    }
    static void DeleteData()
    {
        string cs = "Server=localhost\\SQLEXPRESS;Database=TrainingDB;Trusted_Connection=True;TrustServerCertificate=True;";

        Console.Write("Employee Id to delete: ");
        int id = int.Parse(Console.ReadLine());

        string sql = "DELETE FROM Employees WHERE EmployeeId=@id";

        using (var con = new SqlConnection(cs))
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            int rows = cmd.ExecuteNonQuery();

            Console.WriteLine("Deleted rows: " + rows);
        }
    }
    static void CountEmployees()
    {
        string cs = "Server=localhost\\SQLEXPRESS;Database=TrainingDB;Trusted_Connection=True;TrustServerCertificate=True;";
        string sql = "SELECT COUNT(*) FROM Employees";

        using (var con = new SqlConnection(cs))
        using (var cmd = new SqlCommand(sql, con))
        {
            con.Open();

            int total = Convert.ToInt32(cmd.ExecuteScalar());

            Console.WriteLine("Total Employees: " + total);
        }
    }
    static void SearchByDept()
    {
        string cs = "Server=localhost\\SQLEXPRESS;Database=TrainingDB;Trusted_Connection=True;TrustServerCertificate=True;";

        Console.Write("Enter Department: ");
        string dept = Console.ReadLine();

        string sql = "SELECT EmployeeId,FullName,Salary FROM Employees WHERE Department=@d";

        using (var con = new SqlConnection(cs))
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@d", dept);

            con.Open();

            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    Console.WriteLine(r["EmployeeId"] + " " + r["FullName"] + " " + r["Salary"]);
                }
            }
        }
    }


    static void Main()
    {
        Console.WriteLine("1 Insert");
        Console.WriteLine("2 Show");
        Console.WriteLine("3 Update Salary");
        Console.WriteLine("4 Delete");
        Console.WriteLine("5 Count Employees");
        Console.WriteLine("6 Search By Dept");
        int ch = int.Parse(Console.ReadLine());
        if (ch == 1) InsertData();
        else if (ch == 2) ShowData();
        else if (ch == 3) UpdateSalary();
        else if (ch == 4) DeleteData();
        else if (ch == 5) CountEmployees();
        else if (ch == 6) SearchByDept();
    }

}




