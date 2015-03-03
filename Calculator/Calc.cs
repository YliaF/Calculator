using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calc : ICalc
    {
        public void Calculate(string expression)
        {
            IOperations operations = new OperationsCalculator();
            IParser parser = new ParserString(operations.OperatorList);
            IPostfix obj = new PostfixCalc(operations,parser);
            obj.CreatePostfixExpression(expression);
            obj.Counting();
            Result = obj.CountedResult;
        }
        private double result;
        public double Result
        {
            get { return result; }
            set { result = value; }
        }
    }
}
