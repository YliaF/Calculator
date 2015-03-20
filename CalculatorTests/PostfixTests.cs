using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Calc;

namespace CalculatorTests
{
    [TestClass]
    public class PostfixTests
    {
        [TestMethod]
        public void TestIPostfix()
        {
            string[] test2 = new string[] { "12,5", "5", "1,5", "*", "-", "1", "3", "+", "-" };
            string str = "12,5-5*1,5-(1+3)";

            MyConfigModule module = new MyConfigModule();
            IKernel kernel = new StandardKernel(module);

            IOperations operations = new OperationsCalculator();
            IParseString parser = new ParseString(operations);
            IParsedExpression<string[]> objParsed = new ParsedExpression();
            parser.Parse(str, objParsed);
            IPostfix obj = new Postfix(operations);
            IPostfixExpression<IList<string>> objRes = new PostfixExpression();
            obj.ConvertToPostfix(objParsed, objRes);

            int i = 0;
            foreach (string res in objRes.Result)
            {
                Assert.AreEqual(test2[i], res);
                i++;
            }
        }
        [TestMethod]
        public void TestIPostfixNotInizialized()
        {
            string[] test2 = new string[] { "12,5", "5", "1,5", "*", "-", "1", "3", "+", "-" };
            //string str = "12,5-5*1,5-(1+3)";
            IOperations operations = new OperationsCalculator();
            IParseString parser = new ParseString(operations);

            ParsedExpression objParsed = new ParsedExpression();
            //ParsedExpression objParsed = parser.Parse(str);

            IPostfix obj = new Postfix(operations);
            

            try
            {
                IPostfixExpression<IList<string>> objRes = new PostfixExpression();
                obj.ConvertToPostfix(objParsed, objRes);
                Assert.Fail("no exception thrown");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is Exception);
            }
        }


        /*
        [TestMethod]
        public void TestGetPostfix2()
        {
            string[] test2 = new string[] { "12,5", "5", "1,5", "*", "-", "1", "3", "+", "-" };

            IOperations operations = new OperationsCalculator();
            IToParseString parser = new ToParseString(operations.OperatorList);
            Postfix obj = new ConvertToPostfix(operations, parser);

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
            IToParseString parser = new ToParseString(operations.OperatorList);
            Postfix obj = new ConvertToPostfix(operations, parser);

            obj.CreatePostfixExpression("12,5-5*1,5-(1+2)");

            string[] test = new string[] { "12,5", "5", "1,5", "*", "-", "1", "2", "+", "-" };
            int i = 0;
            foreach (string res in obj.PostfixExpression)
            {
                Assert.AreEqual(test[i], res);
                i++;
            }
        }*/
    }
}
