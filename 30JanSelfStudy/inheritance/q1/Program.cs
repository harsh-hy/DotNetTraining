using System;
class Vehicle
{
    protected string brand;
    public Vehicle(string Br)
    {
        brand = Br;
    }
    public void ShowBrand()
    {
        Console.WriteLine("Brand is "+ brand);
    }
}
class Car:Vehicle
{
    public Car(string brand):base (brand)
    {

    }
    public void ShowCar()
    {
        Console.WriteLine("This is the car 🚗");
    }
}
class Program
{
    static void Main()
    {
        Car car = new Car("RedBull Racing");
        car.ShowBrand();
        car.ShowCar();
    }
}