class Program
{
    public static void Q1IsDigit(string str)
    {
        char[] ar= str.ToCharArray();
        foreach(char ch in ar)
            Console.WriteLine(ch +" is "+char.IsDigit(ch));
    }
    public static void Q2IsLetter(string str)
    {
        char[] ar= str.ToCharArray();
        foreach(char ch in ar)
            Console.WriteLine(ch +" is "+char.IsLetter(ch));
    }
    public static void Q3IsLetterOrDigit(string str)
    {
        char[] ar= str.ToCharArray();
        foreach(char ch in ar)
            Console.WriteLine(ch +" is "+char.IsLetterOrDigit(ch));
    }
    public static void Q4IsUpper(string str)
    {
        char[] ar= str.ToCharArray();
        foreach(char ch in ar)
            Console.WriteLine(ch +" is "+char.IsUpper(ch));
    }
    public static void Q5IsLower(string str)
    {
        char[] ar= str.ToCharArray();
        foreach(char ch in ar)
            Console.WriteLine(ch +" is "+char.IsLower(ch));
    }
    public static void Q6IsWhiteSpace(string str)
    {
        char[] ar= str.ToCharArray();
        foreach(char ch in ar)
            Console.WriteLine(ch +" is "+char.IsWhiteSpace(ch));
    }
    public static void Q7IsSymbol(string str)
    {
        char[] ar= str.ToCharArray();
        foreach(char ch in ar)
            Console.WriteLine(ch +" is "+char.IsSymbol(ch));
    }
    public static void Q8IsPunctuation(string str)
    {
        char[] ar= str.ToCharArray();
        foreach(char ch in ar)
            Console.WriteLine(ch +" is "+char.IsPunctuation(ch));
    }
    public static void Q9IsControl(string str)
    {
        char[] ar= str.ToCharArray();
        foreach(char ch in ar)
            Console.WriteLine(ch +" is "+char.IsControl(ch));
    }
    public static void Q10IsSeparator(string str)
    {
        char[] ar= str.ToCharArray();
        foreach(char ch in ar)
            Console.WriteLine(ch +" is "+char.IsSeparator(ch));
    }

    public static void Main()
    {
        Q1IsDigit("91aaadh2");
        Q2IsLetter("91aaadh2");
        Q3IsLetterOrDigit("91aaadh2");
        Q4IsUpper("91aaadh2");
        Q5IsLower("91aaadh2");
        Q6IsWhiteSpace("91aaadh2");
        Q7IsSymbol("91aaadh2");
        Q8IsPunctuation("91aaadh2");
        Q9IsControl("91aaadh2");
        Q10IsSeparator("91a-/a]\aadh2");
    }
}