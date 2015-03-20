using System.Collections.Generic;

namespace Calc
{
    public interface ICalculatorPostfix
    {
        void Calculate(IPostfixExpression<IList<string>> postfixExpression, IResultCalculator<double> resultCalculator);

        double Calculate(IPostfixExpression<IList<string>> postfixExpression);
    }
}
