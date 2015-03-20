using System.Collections.Generic;

namespace Calc
{
    public class PostfixExpression : IPostfixExpression<IList<string>>
    {
        private IList<string> postfixExpression = new List<string>();
        public IList<string> Result
        {
            get
            {
                return postfixExpression;
            }
            set
            {
                postfixExpression = value;
            }
        }
    }
}
