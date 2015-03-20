using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Calc;
using System.Collections.Generic;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void TestCalculator()
        {
            string expr = "1+2-3";
            var module = new MyConfigModule();
            IKernel kernel = new StandardKernel(module);

            IOperations operations = kernel.Get<OperationsCalculator>();
            IParsedExpression<string[]> parsedExpression = kernel.Get<ParsedExpression>();
            IPostfixExpression<IList<string>> postfixexpression = kernel.Get<PostfixExpression>();
            IResultCalculation<double> resultCalculation = kernel.Get<ResultCalculation>();

            IParseString parseString = new ParseString(operations);          
            parseString.Parse(expr, parsedExpression);
            //IParseString parseString = kernel.Get<ParseString>();

            IPostfix postfix = new Postfix(operations);
            postfix.ConvertToPostfix(parsedExpression,postfixexpression);

            CalculatePostfix calculatePostfix = kernel.Get<CalculatePostfix>();
            calculatePostfix.CalculatePostfixExpression(postfixexpression, resultCalculation);

            Assert.AreEqual(0, resultCalculation.Result);
 
        }
    }
}
