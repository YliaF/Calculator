using System;
using System.Collections.Generic;
using System.Linq;

namespace Calc
{
    public class CalculatorPostfix : ICalculatorPostfix
    {
        private IOperations operations;

        public IOperations Operations
        {
            get { return operations; }
            set { operations = value; }
        }

        public CalculatorPostfix(IOperations operations)
        {
            Operations = operations;
        }

        public void Calculate(IPostfixExpression<IList<string>> postfixExpression, IResultCalculator<double> resultCalculator)
        {
            Stack<double> stackNumber = new Stack<double>();
            double first, second;
            foreach (string token in postfixExpression.Result.ToArray())
            {
                double res = 0;
                if (IsUnaryMinus(token) && stackNumber.Count() != 0)
                {
                    first = -stackNumber.Pop();
                    stackNumber.Push(first);
                }
                else if (!IsOperation(token))
                    try
                    {
                        stackNumber.Push(Convert.ToDouble(token));
                    }
                    catch (FormatException e)
                    {
                        throw new FormatException("The expression contains an invalid character '" + token + "'.\n", e);
                    }

                else
                {
                    try
                    {
                        second = stackNumber.Pop();
                        first = stackNumber.Pop();
                    }
                    catch (Exception e)
                    {
                        throw new Exception("This expression is incorrect.\n", e);
                    }

                    try
                    {
                        res = ApplyOperations(first, second, token);
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message, e);
                    }
                    finally
                    {
                        if (Double.IsInfinity(res))
                            throw new DivideByZeroException("Divide by zero exception.\n");
                    }
                    stackNumber.Push(res);
                }
            }
            resultCalculator.Result = stackNumber.Peek();
        }

        public double Calculate(IPostfixExpression<IList<string>> postfixExpression)
        {
            Stack<double> stackNumber = new Stack<double>();
            double first, second;
            foreach (string token in postfixExpression.Result.ToArray())
            {
                double res = 0;
                if (IsUnaryMinus(token) && stackNumber.Count() != 0)
                {
                    first = -stackNumber.Pop();
                    stackNumber.Push(first);
                }
                else if (!IsOperation(token))
                    try
                    {
                        stackNumber.Push(Convert.ToDouble(token));
                    }
                    catch (FormatException e)
                    {
                        throw new FormatException("The expression contains an invalid character '" + token + "'.\n", e);
                    }

                else
                {
                    try
                    {
                        second = stackNumber.Pop();
                        first = stackNumber.Pop();
                    }
                    catch (Exception e)
                    {
                        throw new Exception("This expression is incorrect.\n", e);
                    }

                    try
                    {
                        res = ApplyOperations(first, second, token);
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message, e);
                    }
                    finally
                    {
                        if (Double.IsInfinity(res))
                            throw new DivideByZeroException("Divide by zero exception.\n");
                    }
                    stackNumber.Push(res);
                }
            }
            return stackNumber.Peek();
        }

        private bool IsOperation(string token)
        {
            return Operations.OperatorList.Contains(token);
        }

        private static bool IsUnaryMinus(string token)
        {
            return token == "_";
        }
        private double ApplyOperations(double first, double second, string token)
        {
            return Operations.BinaryOperations[token](first, second);

        }
    }
}
