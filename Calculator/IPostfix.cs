using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public interface IPostfix
    {
        void CreatePostfixExpression(string inputExpression);
        void Counting();

        IList<string> PostfixExpression { get; set; }

        double CountedResult { get; set; }
    }
}
