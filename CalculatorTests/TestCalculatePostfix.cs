using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calc;

namespace CalculatorTests
{
    [TestClass]
    public class TestCalculatePostfix
    {
        [TestMethod]
        public void TestCalculatePostfixExpr()
        {
            string str = "12,5-5*1,5-(1+3)";
            IOperations operations = new OperationsCalculator();
            IParseString parser = new ParseString(operations);
            IParsedExpression<string[]> objParsed = new ParsedExpression();
            parser.Parse(str, objParsed);
            IPostfix obj = new Postfix(operations);
            IPostfixExpression<IList<string>> objRes = new PostfixExpression();
            obj.ConvertToPostfix(objParsed, objRes);

            CalculatePostfix objCalc = new CalculatePostfix(operations);
            IResultCalculation<double> resultCalculation = new ResultCalculation();
            objCalc.CalculatePostfixExpression(objRes, resultCalculation);
            Assert.AreEqual(1, resultCalculation.Result);
            
        }
    }
}
