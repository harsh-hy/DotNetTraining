public delegate void AlertHandler();
class AlertSystem
{
    public event AlertHandler OnAlarm;
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
    public static void Main()
    {
        AlertSystem al = new AlertSystem();
        al.OnAlarm += SendSMS;
        al.Trigger();
    }
}