using System.Text;
using System.Data;
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

        string sql = "SELECT EmployeeId,FullName,Salary FROM Employees WHERE Department=@d Order by Salary desc";

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
    static void ReadViaAdapter()
    {
        string cs = "Server=localhost\\SQLEXPRESS;Database=TrainingDB;Trusted_Connection=True;TrustServerCertificate=True;";
        string sql = "SELECT EmployeeId, FullName, Department, Salary FROM dbo.Employees";
        DataSet ds = new DataSet();
        using (var con = new SqlConnection(cs))
        using (var cmd = new SqlCommand(sql, con))
        {
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, "Employees");
        }
        ds.WriteXml("TestData.xml");
    }
    static void InsertAdapter()
    {
        string cs = "Server=localhost\\SQLEXPRESS;Database=TrainingDB;Trusted_Connection=True;TrustServerCertificate=True;";
        string sql = "SELECT EmployeeId,FullName,Department,Salary FROM dbo.Employees";
        DataSet ds = new DataSet();
        using (var con = new SqlConnection(cs))
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds, "Employees");
            DataTable table = ds.Tables["Employees"];
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Dept: ");
            string dept = Console.ReadLine();
            Console.Write("Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());
            DataRow newRow = table.NewRow();
            newRow["FullName"] = name;
            newRow["Department"] = dept;
            newRow["Salary"] = salary;
            table.Rows.Add(newRow);
            adapter.Update(ds, "Employees");
            Console.WriteLine("Inserted via DataAdapter");
        }
    }
    static void UpdateViaAdapter()
    {
        string cs = "Server=localhost\\SQLEXPRESS;Database=TrainingDB;Trusted_Connection=True;TrustServerCertificate=True;";
        string sql = "SELECT EmployeeId,FullName,Department,Salary FROM dbo.Employees";
        DataSet ds = new DataSet();
        using (var con = new SqlConnection(cs))
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds, "Employees");
            DataTable table = ds.Tables["Employees"];
            Console.Write("Enter EmployeeId to update: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("New Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());
            foreach (DataRow row in table.Rows)
            {
                if ((int)row["EmployeeId"] == id)
                {
                    row["Salary"] = salary;
                    break;
                }
            }
            adapter.Update(ds, "Employees");
            Console.WriteLine("Updated via DataAdapter");
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
        Console.WriteLine("7 Show Via Adapter");
        Console.WriteLine("8 Insert Via Adapter");
        Console.WriteLine("9 Update Via Adapter");
        int ch = int.Parse(Console.ReadLine());
        if (ch == 1) InsertData();
        else if (ch == 2) ShowData();
        else if (ch == 3) UpdateSalary();
        else if (ch == 4) DeleteData();
        else if (ch == 5) CountEmployees();
        else if (ch == 6) SearchByDept();
        else if (ch == 7) ReadViaAdapter();
        else if (ch == 8) InsertAdapter();
        else if (ch == 9) UpdateViaAdapter();
    }
}