using System;
class Student
{
    private int marks;
    public int Marks {
        get 
        {
            return marks;
        }
        set
        {
            if(value>=0&&value<=100)
                marks=value;
        }
    }
    public static void Main()
    {
        Student st= new Student();
        int x=int.Parse(Console.ReadLine());
        st.Marks=x;
        Console.WriteLine("Marks = "+st.Marks);

    }

}