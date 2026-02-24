public delegate void Alert();
public delegate void Report();
class Program
{
    public static void SoundAlarm()
    {
        Console.WriteLine("Alarm Triggered");
    }
    public static void ShowNotification()
    {
        Console.WriteLine("Notification Shown");
    }
    public static void GeneratePDF()
    {
        Console.WriteLine("GeneratePDF Executed");
    }
    public static void SendEmail()
    {
        Console.WriteLine("SendEmail Executed");
    }
    public static void SaveDatabase()
    {
        Console.WriteLine("SaveDatabase Executed");
    }
    public static void Main()
    {
        Alert al = SoundAlarm;
        al += ShowNotification;
        al.Invoke();
        Console.WriteLine();
        Report r = GeneratePDF;
        r += SendEmail;
        r += SaveDatabase;
        r -= SendEmail;
        r.Invoke();
    }
}