namespace EventBasedTempAlert
{
    public delegate void TemperatureHandler(int temp);
    public class TemperatureMonitor
    {
        public event TemperatureHandler TempEvent;
        public void PrintTemp(int temp)
        {
            if(temp != 0)
            {
                TempEvent?.Invoke(temp);
            }
        }
    }
    public class MainTemp
    {
        public static void HighTempAlert(int temp)
        {
            if(temp > 40)
            {
                Console.WriteLine($"Alert! High Temperature: {temp}°C");
            }
        }
        public static void LowTempAlert(int temp)
        {
            if(temp < 10)
            {
                Console.WriteLine($"Alert! Low Temperature: {temp}°C");
            }
        }
        public static void Main(string[] args)
        {
            TemperatureMonitor monitor = new TemperatureMonitor();
            monitor.TempEvent += HighTempAlert;
            monitor.TempEvent += LowTempAlert;

            int[] temperatures = { 5, 15, 25, 35, 8, 28, 32, 12, 66, 88, 70 };

            foreach(var temp in temperatures)
            {
                monitor.PrintTemp(temp);
            }
        }
    }
}