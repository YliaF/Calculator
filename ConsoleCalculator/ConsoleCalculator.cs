using System;
using Ninject;
using Calc;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class ConsoleCalculator : ICalculator
    {
        private IKernel kernel = new StandardKernel(new MyConfigModule());

        public double Calculate(string inputExpression)
        {
            IOperations operations = kernel.Get<Operations>();

            //Парсинг
            IParsedExpression<string[]> parsedExpression = kernel.Get<ParsedExpression>();
            IParser<string[]> parser = new Parser(operations);
            parsedExpression.Result = parser.Parse(inputExpression);

            //Постфикс
            IPostfixExpression<IList<string>> postfixExpression = kernel.Get<PostfixExpression>();
            IPostfix<IList<string>> postfix = new Postfix(operations);
            postfixExpression.Result = postfix.ConvertToPostfix(parsedExpression);

            //Решение постфикса
            IResultCalculator<double> resultCalculator = kernel.Get<ResultCalculator>();
            ICalculatorPostfix calculatorPostfix = new CalculatorPostfix(operations);
            resultCalculator.Result = calculatorPostfix.Calculate(postfixExpression);

            return resultCalculator.Result;
        }
    }
}
