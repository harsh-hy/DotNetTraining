using System;
public abstract class Consultant
{
    public string ConsultantId { get; set; }
    public Consultant(string id)
    {
        if (!ValidateConsultantId(id))
        {
            Console.WriteLine("Invalid doctor id");
            Environment.Exit(0);
        }
        ConsultantId = id;
    }
    public bool ValidateConsultantId(string id)
    {
        if (id.Length != 6) return false;
        if (!id.StartsWith("DR")) return false;
        for (int i = 2; i < 6; i++)
        {
            if (!char.IsDigit(id[i])) return false;
        }
        return true;
    }
    public abstract double CalculateGrossPayout();
    public virtual double GetTDSRate(double gross)
    {
        if (gross <= 5000) return 0.05;
        return 0.15;
    }
    public void PrintPayout()
    {
        double gross = CalculateGrossPayout();
        double tdsRate = GetTDSRate(gross);
        double net = gross - (gross * tdsRate);
        Console.WriteLine($"Gross: {gross:F2} | TDS Applied: {(tdsRate * 100):0}% | Net Payout: {net:F2}");
    }
}
public class InHouseConsultant : Consultant
{
    public double MonthlyStipend { get; set; }
    public InHouseConsultant(string id, double stipend) : base(id)
    {
        MonthlyStipend = stipend;
    }
    public override double CalculateGrossPayout()
    {
        double allowances = 2000;
        double bonus = 1000;
        return MonthlyStipend + allowances + bonus;
    }
}
public class VisitingConsultant : Consultant
{
    public int ConsultationsCount { get; set; }
    public double RatePerVisit { get; set; }
    public VisitingConsultant(string id, int count, double rate) : base(id)
    {
        ConsultationsCount = count;
        RatePerVisit = rate;
    }
    public override double CalculateGrossPayout()
    {
        return ConsultationsCount * RatePerVisit;
    }
    public override double GetTDSRate(double gross)
    {
        return 0.10;
    }
}
public partial class Program
{
    public static void Main()
    {
        string type = Console.ReadLine();
        if (type == "InHouse")
        {
            string id = Console.ReadLine();
            double stipend = double.Parse(Console.ReadLine());
            Consultant c = new InHouseConsultant(id, stipend);
            c.PrintPayout();
        }
        else if (type == "Visiting")
        {
            string id = Console.ReadLine();
            int visits = int.Parse(Console.ReadLine());
            double rate = double.Parse(Console.ReadLine());
            Consultant c = new VisitingConsultant(id, visits, rate);
            c.PrintPayout();
        }
    }
}