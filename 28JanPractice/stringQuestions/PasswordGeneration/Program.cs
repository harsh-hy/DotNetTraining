using System;
namespace Password
{
    class Program
    {
        public static string PasswordGenerator(string? str, int n)
        {
            if(n!=8)
                return str+" is not a valid username";
            string name="";
            string id="";
            for(int i=0;i<4;i++)
            {
                if(char.IsLetter(str[i]))
                    name+=str[i];
                else
                    return str+" is not a valid username";

            }
            if(str[4]!='@')
                return str+" is not a valid username";
            for(int i=5;i<8;i++)
            {
                if(char.IsDigit(str[i]))
                    id+=str[i];
                else
                    return str+" is not a valid username";
            }
            int asciiSum=0;
            foreach(char ch in name)
            {
                int x=ch;
                asciiSum+=x;
            }
            string strAsciiSum=asciiSum.ToString();
            string? ans="TECH_"+strAsciiSum+id[1]+id[2];
            return ans;
        }
        public static void Main(String[] args)
        {
            Console.Write("Enter the username: ");
            string? username=Console.ReadLine();
            Console.WriteLine();
            int userLength=username.Length;
            string Password=PasswordGenerator(username.ToLower(),userLength);
            Console.WriteLine(Password);
        }
    }
}