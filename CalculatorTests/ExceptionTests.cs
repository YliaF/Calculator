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
            IOperations operations = new OperationsCalculator();
            IParser parser = new ParserString(operations.OperatorList);
            IPostfix obj = new PostfixCalc(operations, parser);
            obj.CreatePostfixExpression("(10+4)%3");
            
            try
            {
                obj.Counting();
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
            IOperations operations = new OperationsCalculator();
            IParser parser = new ParserString(operations.OperatorList);
            IPostfix obj = new PostfixCalc(operations, parser);
            obj.CreatePostfixExpression("(10+4)/0");
            

            try 
            {
                obj.Counting();
                Assert.Fail("no exception thrown");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is DivideByZeroException);
            }
        }
       
    }
}
