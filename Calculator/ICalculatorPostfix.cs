using System.Collections.Generic;

namespace Calc
{
    public interface ICalculatorPostfix
    {
        double Calculate(IPostfixExpression<IList<string>> postfixExpression);
    }
}
