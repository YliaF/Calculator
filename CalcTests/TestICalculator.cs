using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calc;
using System.Collections.Generic;

namespace CalcTests
{
    [TestClass]
    public class TestICalculator
    {
        [TestMethod]
        public void TestICalculatorAll()
        {
            string inputExpression = "1+2-3-4";

            //Операции
            IOperations operations = new Operations();

            //Парсинг
            IParsedExpression<string[]> parsedExpression = new ParsedExpression();
            IParser<string[]> parser = new Parser(operations);
            parsedExpression.Result = parser.Parse(inputExpression);

            //Постфикс
            IPostfixExpression<IList<string>> postfixExpression = new PostfixExpression();
            IPostfix<IList<string>> postfix = new Postfix(operations);
            postfixExpression.Result = postfix.ConvertToPostfix(parsedExpression);

            //Решение постфикса
            IResultCalculator<double> resultCalculator = new ResultCalculator();
            ICalculatorPostfix calculatorPostfix = new CalculatorPostfix(operations);
            resultCalculator.Result = calculatorPostfix.Calculate(postfixExpression);

            Assert.AreEqual(-4, resultCalculator.Result);
        }
    }
}
