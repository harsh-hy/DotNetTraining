using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLocalNameSpace;

namespace MyLocalNameSpace
{
    public class Student
    {
        
        public int Id { get; set; }
    }

    public class UGStudent : Student
    {
        public int HighSchoolMark { get; set; }
    }

    public class PGStudent : UGStudent
    {
        public int UGMark { get; set; }
    }
}
namespace LearningCSharp
{

    public class CallerClass
    {
        public static void Main(string[] args)
        {
            MyGlobalType<UGStudent> myGlobalType = new MyGlobalType<UGStudent>();
            //MyGlobalType<Object> myGlobalType1 = new MyGlobalType<Object>();

            UGStudent obj = new UGStudent();
            string result = myGlobalType.GetDataType(obj);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
    public class MyGlobalType<T> where T : Student
    {
        public List<T> MyCollection { get; set; }
        public string GetDataType(T t)
        {
            
            return t.GetType().ToString();
        }

        public void AddItem(T t)
        {
            MyCollection.Add(t);
        }

        public List<T> GetCollection()
        {
            return MyCollection;
        }

        public string ActBasedOnType(T t)
        {
            if (t is PGStudent)
            {
                return "Type is PGStudent";
            }
            if (t is UGStudent)
            {
                return "Type isU UG";
            }
            return "Student";

        }

    }

    public class MyGlobalType2<T, K>
    {
        //public K MyProperty { get; set; }
        public void MyGLobalFunction(T t, K k)
        {
             
        }
    }
}