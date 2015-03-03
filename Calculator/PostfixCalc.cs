using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Calculator
{
    public class PostfixCalc
    {
        private OperationsCalculator op = new OperationsCalculator();

        public OperationsCalculator Operations
        {
            get { return op; }
            set { op = value; }
        }
        private List<string> postfixExpression = new List<string>();
        private double countedResult;

        private bool countedResultInitialized = false;
        public List<string> PostfixExpression
        {
            get { return postfixExpression; }
            set { postfixExpression = value; }
        }

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
        public PostfixCalc(string inputExpr)
        {
            ParserString objParserString = new ParserString(op.OperatorList, inputExpr);
            GetPostfix(objParserString.ResultString);
        }

        public PostfixCalc()
        {
        }
        public void GetPostfix(string inputExpr)
        {
            ParserString objParserString = new ParserString(op.OperatorList, inputExpr);
            GetPostfix(objParserString.ResultString);
        }

        public void GetPostfix(string[] ProcStr)
        {
            Stack<string> stackOperators = new Stack<string>();
            foreach (string token in ProcStr)
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
                return op.PriorityOperations[token];
            }
            catch (KeyNotFoundException e)
            {
                throw new KeyNotFoundException("For operation ' " + token + " ' is not set priority.\n", e);
            }
            
        }

        private bool IsOperation(string token)
        {
            return op.OperatorList.Contains(token);
        }

        private double ApplyOperations(double first, double second, string token)
        {
            return op.BinaryOperations[token](first, second);

        }

        
    }
}
