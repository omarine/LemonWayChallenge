using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LemonWayChallenge.Services.Tests
{
    [TestClass()]
    public class FibonacciServiceTests
    {
        FibonacciService FbCalculator = new FibonacciService();
        [TestMethod()]
        public void FibonacciTestWith1()
        {
            //testing positive values
            int a = 1;
            int result = FbCalculator.Fibonacci(a);
            Assert.AreEqual(1, result);
        }
        [TestMethod()]
        public void FibonacciTestWith0()
        {
            int a = 0;
            int result = FbCalculator.Fibonacci(a);
            Assert.AreEqual(-1, result);
        }
        [TestMethod()]
        public void FibonacciTestWithMinus10()
        {
            int a = -10;
            int result = FbCalculator.Fibonacci(a);
            Assert.AreEqual(-1, result);
        }
        [TestMethod()]
        public void FibonacciTestWith1000()
        {
            int a = 1000;
            int result = FbCalculator.Fibonacci(a);
            Assert.AreEqual(-1, result);
        }
    }
}