using System;

namespace Fields
{
    public class Field
    {
        private int id;   // private field

        public int Id     // public property
        {
            get
            {
                return id;
            }
            set
            {
                if (value <= 0)
                    throw new InvalidOperationException("Id must be greater than 0");

                id = value;
            }
        }

        public string DisplayEmpDetails()
        {
            return $"Employee Id is {id}";
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                Field emp = new Field();
                emp.Id = 10;   // valid
                Console.WriteLine(emp.DisplayEmpDetails());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
