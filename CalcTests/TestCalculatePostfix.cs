using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calc;
using System.Collections.Generic;

namespace CalcTests
{
    [TestClass]
    public class TestCalculatePostfix
    {
        [TestMethod]
        public void TestReturnCalculatePostfixExpression()
        {
            IOperations operations = new Operations();

            IPostfixExpression<IList<string>> postfixExpression = new PostfixExpression()
            {
                Result = new string[] { "1", "2", "+", "3", "-" }
            };
            IResultCalculator<double> resultCalculator = new ResultCalculator();
            ICalculatorPostfix calculatorPostfix = new CalculatorPostfix(operations);
            resultCalculator.Result = calculatorPostfix.Calculate(postfixExpression);

            Assert.AreEqual(0,resultCalculator.Result);
        }
        [TestMethod]
        public void TestVoidCalculatePostfixExpression()
        {
            IOperations operations = new Operations();

            IPostfixExpression<IList<string>> postfixExpression = new PostfixExpression()
            {
                Result = new string[] { "1", "2", "+", "3", "-" }
            };
            
            ICalculatorPostfix calculatorPostfix = new CalculatorPostfix(operations);
            IResultCalculator<double> resultCalculator = new ResultCalculator();
            calculatorPostfix.Calculate(postfixExpression,resultCalculator);

            Assert.AreEqual(0, resultCalculator.Result);
        }
    }
}
