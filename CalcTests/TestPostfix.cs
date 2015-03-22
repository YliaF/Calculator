using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calc;
using System.Collections.Generic;

namespace CalcTests
{
    [TestClass]
    public class TestPostfix
    {
        [TestMethod]
        public void TestConvertToPostfix()
        {
            IOperations operations = new Operations();

            string[] test = { "1", "2", "+", "3","-"};


            IParsedExpression<string[]> parsedExpression = new ParsedExpression()
            {
                Result = new string[] { "1", "+", "2", "-", "3" }
            };

            IPostfixExpression<IList<string>> postfixExpression = new PostfixExpression();
            IPostfix<IList<string>> postfix = new Postfix(operations);
            postfixExpression.Result = postfix.ConvertToPostfix(parsedExpression);

            int i = 0;
            foreach (string res in postfixExpression.Result)
            {
                Assert.AreEqual(test[i], res);
                i++;
            }
        }
       
    }
}
