using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class AdditionOperationsTests
    {
        
        [TestMethod]
        public void AddOperationsModCounting()
        {
            IOperations operations = new OperationsCalculator();
            operations.AddBinaryOperation("%", (x, y) => x % y);
            operations.SetPriorityOperations("%", 3);
            IParser parser = new ParserString(operations.OperatorList);
            IPostfix obj = new PostfixCalc(operations, parser);

            obj.CreatePostfixExpression("(10+4)%3+(5-1)");

            Assert.AreEqual(6, obj.CountedResult);
        }
       
    }
}
