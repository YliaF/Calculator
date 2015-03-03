using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Calculator
{
    public class PostfixCalc: IPostfix
    {

        private IOperations operations;

        public IOperations Operations
        {
            get { return operations; }
            set { operations = value; }
        }

        private IParser parser;

        public IParser Parser
        {
            get { return parser; }
            set { parser = value; }
        }

        private IList<string> postfixExpression = new List<string>();

        public IList<string> PostfixExpression
        {
            get { return postfixExpression; }
            set { postfixExpression = value; }
        }

        private bool countedResultInitialized = false;

        private double countedResult;

        public double CountedResult
        {
            get
            {
                if (!countedResultInitialized)
                    Counting();
                return countedResult;
            }
            set { countedResult = value; }
        }

        public PostfixCalc()
        {
        }

        public PostfixCalc(IOperations operations, IParser parser)
        {
            Operations = operations;
            Parser = parser;
        }
        public void CreatePostfixExpression(string inputExpression)
        {
            GetPostfix(Parser.ParseExpression(inputExpression));
        }

        public void GetPostfix(string[] parseString)
        {
            Stack<string> stackOperators = new Stack<string>();
            foreach (string token in parseString)
            {
                if (token == "(")
                    stackOperators.Push(token);
                else if (IsOperation(token))
                {
                    while ((stackOperators.Count != 0) && (Priority(stackOperators.Peek()) >= Priority(token)))
                    {
                        PostfixExpression.Add(stackOperators.Pop());
                    }
                    stackOperators.Push(token);
                }
                else if (token == ")")
                {
                    while ((stackOperators.Count() != 0) && (stackOperators.Peek() != "("))
                    {
                        PostfixExpression.Add(stackOperators.Pop());
                    }
                    if (stackOperators.Count() == 0)
                        throw new Exception("This expression is incorrect.\n");
                    stackOperators.Pop();
                }
                else
                {
                    PostfixExpression.Add(token);
                }
            }
            while (stackOperators.Count() != 0)
            {
                PostfixExpression.Add(stackOperators.Pop());
            }
        }

        public void Counting()
        {
            Stack<double> stackNumber = new Stack<double>();
            double first, second;
            foreach (string token in this.PostfixExpression.ToArray())
            {
                double res = 0;
                if (IsUnaryMinus(token) && stackNumber.Count() != 0)
                {
                    first = -stackNumber.Pop();
                    stackNumber.Push(first);
                }
                else if (!IsOperation(token))
                    try{
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
                    catch(Exception e)
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
            CountedResult = stackNumber.Peek();
            countedResultInitialized = true;
        }

        private static bool IsUnaryMinus(string token)
        {
            return token == "_";
        }
        private int Priority(string token)
        {
            try
            {
                return Operations.PriorityOperations[token];
            }
            catch (KeyNotFoundException e)
            {
                throw new KeyNotFoundException("For operation ' " + token + " ' is not set priority.\n", e);
            }
            
        }

        private bool IsOperation(string token)
        {
            return Operations.OperatorList.Contains(token);
        }

        private double ApplyOperations(double first, double second, string token)
        {
            return Operations.BinaryOperations[token](first, second);

        }

        
    }
}
