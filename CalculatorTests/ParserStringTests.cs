using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class ParserStringTests
    {
        [TestMethod]
        public void TestProcessingString()
        {
            string str = "-12,5-5*1,5-(1+3)";
            string[] StrParse = new string[] { "_", "12,5", "-", "5", "*", "1,5", "-", "(", "1", "+", "3", ")" };
            IOperations operations = new OperationsCalculator();
            IParser parser = new ParserString(operations.OperatorList);
            string[] result = parser.ParseExpression(str);
            int i = 0;
            foreach (string res in result)
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
            IParser parser = new ParserString(operations.OperatorList);
            string[] result = parser.ParseExpression(str);
            int i = 0;
            foreach (string res in result)
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
            IParser parser = new ParserString(operations.OperatorList);
            string[] result = parser.ParseExpression(str);
            int i = 0;
            foreach (string res in result)
            {
                Assert.AreEqual(StrParse[i], res);
                i++;
            }
        }

    }
}
