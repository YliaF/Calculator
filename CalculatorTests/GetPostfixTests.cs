using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class GetPostfixTests
    {

        [TestMethod]
        public void TestGetPostfix2()
        {

            string[] test1 = new string[] { "12,5", "-", "5", "*", "1,5" };
            string[] test2 = new string[] { "12,5", "5", "1,5", "*", "-", "1", "3", "+", "-" };

            PostfixCalc postfixExpr = new PostfixCalc("12,5-5*1,5-(1+3)");
            int i = 0;
            foreach (string res in postfixExpr.PostfixExpression)
            {
                Assert.AreEqual(test2[i], res);
                i++;
            }
        }

        [TestMethod]
        public void TestNewPOSTFIX()
        {
            PostfixCalc pE = new PostfixCalc("12,5-5*1,5-(1+2)");
            string[] test = new string[] { "12,5", "5", "1,5", "*", "-", "1", "2", "+", "-" };
            int i = 0;
            foreach (string res in pE.PostfixExpression)
            {
                Assert.AreEqual(test[i], res);
                i++;
            }
            //Assert.AreEqual(2, pE.CountedResult);

        }
    }
}
