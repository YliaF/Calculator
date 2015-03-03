using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class AdditionOperationsTests
    {
        [TestMethod]
        public void AddOperationsMod()
        {
           
            OperationsCalculator op = new OperationsCalculator();
            op.AddBinaryOperation("%",(x,y)=> x%y);
            //op.SetPriorityOperations("%",3);

            
            PostfixCalc objPostfix = new PostfixCalc();
            objPostfix.Operations = op;

            string[] test = new string[] { "10", "4", "+", "3", "%" };

            objPostfix.GetPostfix("(10+4)%3");

            int i = 0;
            foreach (string res in objPostfix.PostfixExpression)
            {
                Assert.AreEqual(test[i], res);
                i++;
            }
        }
        [TestMethod]
        public void AddOperationsModCounting()
        {

            OperationsCalculator op = new OperationsCalculator();
            op.AddBinaryOperation("%", (x, y) => x % y);
            op.SetPriorityOperations("%",3);


            PostfixCalc objPostfix = new PostfixCalc();
            objPostfix.Operations = op;

            //string[] test = new string[] { "10", "4", "+", "3", "%" };

            objPostfix.GetPostfix("(10+4)%3+(5-1)");

            Assert.AreEqual(6, objPostfix.CountedResult);
        }
        [TestMethod]
        public void AddOperationsPower()
        {

            OperationsCalculator op = new OperationsCalculator();
            op.AddBinaryOperation("^", (x, y) => Math.Pow(x,y));
            op.SetPriorityOperations("^",4);


            PostfixCalc objPostfix = new PostfixCalc();
            objPostfix.Operations = op;

            objPostfix.GetPostfix("(10-8)^3-(5+1)");

            Assert.AreEqual(2, objPostfix.CountedResult);
        }
       
    }
}
