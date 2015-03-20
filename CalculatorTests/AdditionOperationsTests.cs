using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calc;

namespace CalculatorTests
{
    [TestClass]
    public class AdditionOperationsTests
    {
       /* 
        [TestMethod]
        public void AddOperationsMod()
        {
            IOperations operations = new OperationsCalculator();
            operations.AddBinaryOperation("%", (x, y) => x % y);
            operations.SetPriorityOperations("%", 3);
            IToParseString parser = new ToParseString(operations.OperatorList);
            Postfix obj = new ConvertToPostfix(operations, parser);

            obj.CreatePostfixExpression("(10+4)%3+(5-1)");

            obj.Counting();

            Assert.AreEqual(6, obj.CountedResult);
        }

        [TestMethod]
        public void AddOperationsPow()
        {
            IOperations operations = new OperationsCalculator();
            operations.AddBinaryOperation("^", (x, y) => Math.Pow(x,y));
            operations.SetPriorityOperations("^", 3);
            IToParseString parser = new ToParseString(operations.OperatorList);
            Postfix obj = new ConvertToPostfix(operations, parser);

            obj.CreatePostfixExpression("(10-8)^3+(5-1)");

            obj.Counting();

            Assert.AreEqual(12, obj.CountedResult);
        }
       */
    }
}
