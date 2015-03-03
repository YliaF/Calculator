using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    public interface ICalc
    {
        void Calculate(string expression);
        double Result { get; set; }
    }
}
