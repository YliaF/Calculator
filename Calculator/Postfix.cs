using System;
using System.Collections.Generic;
using System.Linq;

namespace Calc
{
    public class Postfix : IPostfix<IList<string>>
    {
        private IOperations operations;

        public IOperations Operations
        {
            get { return operations; }
            set { operations = value; }
        }

        public Postfix(IOperations operations)
        {
            Operations = operations;
        }
        public IList<string> ConvertToPostfix(IParsedExpression<string[]> parsedExpression)
        {
            IList<string> postfix = new List<string>();

            Stack<string> stackOperators = new Stack<string>();
            foreach (string token in parsedExpression.Result)
            {
                if (token == "(")
                    stackOperators.Push(token);
                else if (IsOperation(token))
                {
                    while ((stackOperators.Count != 0) && (Priority(stackOperators.Peek()) >= Priority(token)))
                    {
                        postfix.Add(stackOperators.Pop());
                    }
                    stackOperators.Push(token);
                }
                else if (token == ")")
                {
                    while ((stackOperators.Count() != 0) && (stackOperators.Peek() != "("))
                    {
                        postfix.Add(stackOperators.Pop());
                    }
                    if (stackOperators.Count() == 0)
                        throw new Exception("This expression is incorrect.\n");
                    stackOperators.Pop();
                }
                else
                {
                    postfix.Add(token);
                }
            }
            while (stackOperators.Count() != 0)
            {
                postfix.Add(stackOperators.Pop());
            }
            return postfix;
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


    }
}
