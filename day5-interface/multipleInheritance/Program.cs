using System;

namespace MultipleInheritanceExample
{
    public interface IVegEaterian
    {
        void ShowDiet();
    }

    public interface INonVegEaterian
    {
        void ShowDiet();
    }

    public class VegEaterian
    {
        public void ShowDiet()
        {
            Console.WriteLine("Vegetarian Diet: Includes vegetables, fruits, grains, and nuts.");
        }
    }

    public class NonVegEaterian
    {
        public void ShowDiet()
        {
            Console.WriteLine("Non-Vegetarian Diet: Includes meat, fish, and poultry.");
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

        void INonVegEaterian.ShowDiet()
        {
            nonVeg.ShowDiet();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Visitor v = new Visitor();

            IVegEaterian vegVisitor = v;
            vegVisitor.ShowDiet();

            INonVegEaterian nonVegVisitor = v;
            nonVegVisitor.ShowDiet();
        }
    }
}
