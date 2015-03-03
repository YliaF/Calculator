using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class CoutingPostfixTests
    {
        [TestMethod]
        public void TestCouting()
        {
            Calc consCalc = new Calc();
            //consCalc.Calculate("(1+2)*3-6/(1+2)"); //=7
            consCalc.Calculate("1+3-4");
            Assert.AreEqual(0, consCalc.Result);

        }
    }
}
