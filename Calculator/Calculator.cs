using System.Collections.Generic;
using Ninject;
namespace Calc
{
    public class Calculator: ICalculator
    {
        private IKernel kernel = new StandardKernel(new MyConfigModule());

        public double Calculate(string inputExpression)
        {
            IOperations operations = kernel.Get<IOperations>();

            //Парсинг
            IParsedExpression<string[]> parsedExpression = kernel.Get<IParsedExpression<string[]>>();
            IParser<string[]> parser = kernel.Get<IParser<string[]>>();
            parser.Operations = operations;
            parsedExpression.Result = parser.Parse(inputExpression);

            //Постфикс
            IPostfixExpression<IList<string>> postfixExpression = kernel.Get<IPostfixExpression<IList<string>>>();
            IPostfix<IList<string>> postfix = kernel.Get<IPostfix<IList<string>>>();
            postfix.Operations = operations;
            postfixExpression.Result = postfix.ConvertToPostfix(parsedExpression);

            //Решение постфикса
            IResultCalculator<double> resultCalculator = kernel.Get<IResultCalculator<double>>();
            ICalculatorPostfix calculatorPostfix = kernel.Get<ICalculatorPostfix>();
            calculatorPostfix.Operations = operations;

            resultCalculator.Result = calculatorPostfix.Calculate(postfixExpression);

            return resultCalculator.Result;
        }
    }
}
