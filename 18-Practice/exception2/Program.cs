class Program
{
    public static void Main()
    {
        try
        {
            int age = int.Parse(Console.ReadLine());
            if(age<18)
                throw new ArgumentException("Not eligible to vote");
        }
        catch(ArgumentException  ex){
            Console.WriteLine(ex.Message);
        }
    }
}