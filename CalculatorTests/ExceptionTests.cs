using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calc;

namespace CalculatorTests
{
    [TestClass]
    public class ExceptionTests
    {/*
        [TestMethod]
        public void ConvertToDouble()
        {
            IOperations operations = new OperationsCalculator();
            IToParseString parser = new ToParseString(operations.OperatorList);
            Postfix obj = new ConvertToPostfix(operations, parser);
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
            IToParseString parser = new ToParseString(operations.OperatorList);
            Postfix obj = new ConvertToPostfix(operations, parser);
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
        }*/
       
    }
}
