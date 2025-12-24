using System;

namespace MultipleInheritanceExample
{
    public interface IVegEaterian
    {
        void ShowDiet();
        string GetTaste();
    }

    public interface INonVegEaterian
    {
        void ShowDiet();
        string GetTaste();
    }

    public class VegEaterian
    {
        public void ShowDiet()
        {
            Console.WriteLine("Vegetarian Diet: Includes vegetables, fruits, grains, and nuts.");
        }

        public string GetTaste()
        {
            return "Mild and fresh.";
        }
    }

    public class NonVegEaterian
    {
        public void ShowDiet()
        {
            Console.WriteLine("Non-Vegetarian Diet: Includes meat, fish, and poultry.");
        }
        public string GetTaste()
        {
            return "Rich and savory.";
        }
    }

    public class Visitor : IVegEaterian, INonVegEaterian
    {
        VegEaterian veg = new VegEaterian();
        NonVegEaterian nonVeg = new NonVegEaterian();

        void IVegEaterian.ShowDiet()
        {
            veg.ShowDiet();
        }
        string IVegEaterian.GetTaste()
        {
            return veg.GetTaste();
        }


        void INonVegEaterian.ShowDiet()
        {
            nonVeg.ShowDiet();
        }
        string INonVegEaterian.GetTaste()
        {
            return nonVeg.GetTaste();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Visitor v = new Visitor();

            IVegEaterian vegVisitor = v;
            vegVisitor.ShowDiet();
            string vTaste = vegVisitor.GetTaste();
            Console.WriteLine("Vegetarian Taste: " + vTaste);
            INonVegEaterian nonVegVisitor = v;
            nonVegVisitor.ShowDiet();
            string nvTaste = nonVegVisitor.GetTaste();
            Console.WriteLine("Non-Vegetarian Taste: " + nvTaste);
        }
    }
}
