using System;
class Program
{
    public static void Main()
    {
        string email = Console.ReadLine();
        int len = email.Length;
        string orig ="@gmail.com";
        bool charCheck=true;
        int atCount=0;
        bool prevDot=false;
        char[] emailAr = email.ToCharArray();
        int i=1;
        foreach(char ch in emailAr)
        {
            if (!(char.IsAsciiLetterOrDigit(ch) || ch == '.' || ch=='@'))
            {
                charCheck=false;
                break;
            }
            if (ch == '.' && prevDot)
            {
                charCheck = false;
                break;
            }
            prevDot = (ch == '.');
            if(ch=='@')
                atCount++;
        }
        bool endsCorrectly = email.Length >= orig.Length && email.EndsWith(orig);
        if(!charCheck||atCount!=1||!endsCorrectly)
            Console.WriteLine("False");
        else
            Console.WriteLine("True");
    }
}