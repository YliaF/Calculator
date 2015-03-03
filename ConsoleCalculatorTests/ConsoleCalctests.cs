using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleCalculator;

namespace ConsoleCalculatorTests
{
    [TestClass]
    public class ConsoleCalctests
    {
        [TestMethod]
        public void TestMethod1()
        {
            ConsoleCalc obj = new ConsoleCalc();
            obj.Run();
        }
    }
}
