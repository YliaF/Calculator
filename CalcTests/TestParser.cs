using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calc;

namespace CalcTests
{
    [TestClass]
    public class TestParser
    {
        [TestMethod]
        public void TestReturnParsing()
        {
            string inputExpression = "1+2-3";
            string[] test = { "1", "+", "2", "-","3"}; 

            IOperations operations = new Operations();
      
            IParsedExpression<string[]> parsedExpression = new ParsedExpression();
            IParser<string[]> parser = new Parser(operations);
            parsedExpression.Result = parser.Parse(inputExpression);

            int i = 0;
            foreach (string res in parsedExpression.Result)
            {
                Assert.AreEqual(test[i], res);
                i++;
            }
        }
        [TestMethod]
        public void TestVoidParsing()
        {
            string inputExpression = "1+2-3";
            string[] test = { "1", "+", "2", "-", "3" };

            IOperations operations = new Operations();
            //Парсинг
            IParsedExpression<string[]> parsedExpression = new ParsedExpression();
            IParser<string[]> parser = new Parser(operations);
            parser.Parse(inputExpression,parsedExpression);

            int i = 0;
            foreach (string res in parsedExpression.Result)
            {
                Assert.AreEqual(test[i], res);
                i++;
            }
        }
    }
}
