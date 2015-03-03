using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class ExceptionTests
    {
        [TestMethod]
        public void ConvertToDouble()
        {
            PostfixCalc objPostfix = new PostfixCalc("(10+4)%3");

            try
            {
                objPostfix.Counting();
                Assert.Fail("no exception thrown");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is FormatException);
            }
        }

        [TestMethod]
        public void DivisionByZero()
        {
            PostfixCalc objPostfix = new PostfixCalc("(10+4)/0");

            try 
            {
                objPostfix.Counting();
                Assert.Fail("no exception thrown");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is DivideByZeroException);
            }
        }
       
    }
}
