using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calc;
using Moq;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void TestICalculatorIResult()
        {
            ICalculator objCalc = new Calc();
            IResultCalculation<double> resultCalculation = new ResultCalculation();
   
            objCalc.Calculate("0.5", resultCalculation);
            Assert.AreEqual(0.5, resultCalculation.Result);
        }
    }
}
