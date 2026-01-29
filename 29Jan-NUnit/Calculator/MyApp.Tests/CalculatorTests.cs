using NUnit.Framework;
using CalculatorApp;
using System;

namespace CalculatorApp.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator;
        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }
        [Test]
        public void AddTest()
        {
            int result = calculator.Add(10, 5);
            Assert.That(result, Is.EqualTo(15));
        }
        [Test]
        public void SubtractTest()
        {
            int result = calculator.Subtract(10, 3);
            Assert.That(result, Is.EqualTo(7));
        }
        [Test]
        public void MultiplyTest()
        {
            int result = calculator.Multiply(4, 5);
            Assert.That(result, Is.EqualTo(20));
        }
        // failed test!
        // [Test]
        // public void Multiply_WhenCalled_ReturnsCorrectResult_1()
        // {
        //     int result = calculator.Multiply(4, 5);
        //     Assert.That(result, Is.EqualTo(21));
        // }
        [Test]
        public void fnc1()
        {
            int result=calculator.Multiply(99,10);
            Assert.That(result, Is.EqualTo(990));
        }
        [TestCase(4, 5, 9)]
        [TestCase(0, 10, 10)]
        [TestCase(-2, 3, 1)]
        public void TestViaPara(int a,int b, int ans)
        {
            int res=calculator.Add(a,b);
            Assert.That(ans, Is.EqualTo(res));
        }
        // [Test]
        // public void Divide_ByZero_ThrowsException()
        // {
        //     Assert.That(() => calculator.Divide(10, 0),
        //                       Throws.TypeOf<DivideByZeroException>()
        //                       .With.Message.EqualTo("Divider cannot be zero"));

        // }
        [Test]
        public void Divide_ByZero_Test()
        {
            Assert.That(() => calculator.Divide(10, 0),Throws.TypeOf<DivideByZeroException>());
        }
        [Test]
        public void GetNumbers_List_Test()
        {
            var result = calculator.GetNumbers();
            Assert.That(result, Has.Exactly(3).Items);
            Assert.That(result, Is.Unique);
            Assert.That(result, Contains.Item(2));
        }
        //multiple exception handling
        [TestCase(10, 0, typeof(DivideByZeroException))]
        [TestCase(10, -1, typeof(ArgumentException))]
        public void MultipleException(int a, int b, Type expectedException)
        {
            Assert.That(() => calculator.Divide(a, b),Throws.TypeOf(expectedException));
        }
    }
}
