public delegate void AlarmSystem();
class AlarmHandler
{
    public event AlarmSystem OnAlarm;
    public void Trigger()
    {
        Console.WriteLine("Alarm Triggered");
        OnAlarm?.Invoke();
    }
}
class Program
{
    public static void SendSMS()
    {
        Console.WriteLine("SMS Sent");
    }
    public static void CallPolice()
    {
        Console.WriteLine("Police Called");
    }
    public static void Main()
    {
        AlarmHandler al = new AlarmHandler();
        al.OnAlarm += SendSMS;
        al.OnAlarm += CallPolice;
        al.Trigger();
    }
}