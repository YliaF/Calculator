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
            string[] test2 = new string[] { "12,5", "5", "1,5", "*", "-", "1", "3", "+", "-" };

            IOperations operations = new OperationsCalculator();
            IParser parser = new ParserString(operations.OperatorList);
            IPostfix obj = new PostfixCalc(operations, parser);

            obj.CreatePostfixExpression("12,5-5*1,5-(1+3)");
    
            int i = 0;
            foreach (string res in obj.PostfixExpression)
            {
                Assert.AreEqual(test2[i], res);
                i++;
            }
        }

        [TestMethod]
        public void TestNewPOSTFIX()
        {
            IOperations operations = new OperationsCalculator();
            IParser parser = new ParserString(operations.OperatorList);
            IPostfix obj = new PostfixCalc(operations, parser);

            obj.CreatePostfixExpression("12,5-5*1,5-(1+2)");

            string[] test = new string[] { "12,5", "5", "1,5", "*", "-", "1", "2", "+", "-" };
            int i = 0;
            foreach (string res in obj.PostfixExpression)
            {
                Assert.AreEqual(test[i], res);
                i++;
            }
        }
    }
}
