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
            OperationsCalculator objStOpers = new OperationsCalculator();
            ParserString objProcStr = new ParserString(objStOpers.OperatorList, str);
            //ProcessingString objProcStr = new ProcessingString(str);

            int i = 0;
            foreach (string res in objProcStr.ResultString)
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
            OperationsCalculator objStOpers = new OperationsCalculator();
            ParserString objProcStr = new ParserString(objStOpers.OperatorList, str);
            //ProcessingString objProcStr = new ProcessingString(str);

            int i = 0;
            foreach (string res in objProcStr.ResultString)
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
            OperationsCalculator objStOpers = new OperationsCalculator();
            ParserString objProcStr = new ParserString(objStOpers.OperatorList, str);

            int i = 0;
            foreach (string res in objProcStr.ResultString)
            {
                Assert.AreEqual(StrParse[i], res);
                i++;
            }
        }

    }
}
