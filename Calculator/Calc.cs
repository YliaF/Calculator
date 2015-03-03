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
            PostfixCalc obj = new PostfixCalc(expression);
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
