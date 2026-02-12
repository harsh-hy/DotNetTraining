    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the password ");
            string? pass = Console.ReadLine();
            int len=pass.Length;
            if(len<3)
                Console.WriteLine("passworrd too short to mask");
            else
            {
                char[] maskPass=pass.ToCharArray();
                for(int i=1;i<len-1;i++)
                    maskPass[i]='*';
                Console.WriteLine("Welcome: "+new string(maskPass));
            }
        }
    }