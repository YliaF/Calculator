using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject;
using Ninject.Modules;
using Calc;

namespace CalculatorTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_IoCNinjectParseString()
        {
            MyConfigModule module = new MyConfigModule();
            IKernel kernel = new StandardKernel(module);

            string str = "-12,5-5*1,5-(1+3)";
            string[] StrParse = new string[] { "_", "12,5", "-", "5", "*", "1,5", "-", "(", "1", "+", "3", ")" };
 
            IParseString parser = kernel.Get<ParseString>();
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
