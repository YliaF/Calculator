using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calc;

namespace CalculatorTests
{
    [TestClass]
    public class ParserStringTests
    {

        [TestMethod]
        public void TestIParseString()
        {
            string str = "-12,5-5*1,5-(1+3)";
            string[] StrParse = new string[] { "_", "12,5", "-", "5", "*", "1,5", "-", "(", "1", "+", "3", ")" };
            IOperations operations = new OperationsCalculator();
            IParseString parser = new ParseString(operations);
            IParsedExpression<string[]> obj = new ParsedExpression();
            parser.Parse(str,obj);
            int i = 0;
            foreach (string res in obj.Result)
            {
                Assert.AreEqual(StrParse[i], res);
                i++;
            }
        }

       [TestMethod]
        public void TestProcessingString()
        {
            string str = "-12,5-5*1,5-(1+3)";
            string[] StrParse = new string[] { "_", "12,5", "-", "5", "*", "1,5", "-", "(", "1", "+", "3", ")" };
            IOperations operations = new OperationsCalculator();
            IParseString parser = new ParseString(operations);
            IParsedExpression<string[]> obj = new ParsedExpression();
            parser.Parse(str, obj);
            int i = 0;
            foreach (string res in obj.Result)
            {
                Assert.AreEqual(StrParse[i], res);
                i++;
            }
        }

        [TestMethod]
        public void TestParserUnaryMinus()
        {
            string str = "-7+(5+3)-9";
            string[] StrParse = new string[] { "_", "7", "+", "(", "5", "+", "3", ")", "-", "9" };
            IOperations operations = new OperationsCalculator();
            IParseString parser = new ParseString(operations);
            IParsedExpression<string[]> obj = new ParsedExpression();
            parser.Parse(str, obj);
            int i = 0;
            foreach (string res in obj.Result)
            {
                Assert.AreEqual(StrParse[i], res);
                i++;
            }
        }


        [TestMethod]
        public void TestParserMod()
        {

            string str = "(10+4)%3";
            string[] StrParse = new string[] { "(", "10", "+", "4", ")", "%3" };
            IOperations operations = new OperationsCalculator();
            IParseString parser = new ParseString(operations);
            IParsedExpression<string[]> obj = new ParsedExpression();
            parser.Parse(str, obj);
            int i = 0;
            foreach (string res in obj.Result)
            {
                Assert.AreEqual(StrParse[i], res);
                i++;
            }
        }
    }
}
