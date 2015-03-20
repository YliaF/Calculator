
namespace Calc
{
    public class ParsedExpression : IParsedExpression<string[]>
    {
        private string[] parsedExpression;
        public string[] Result
        {
            get
            {
                return parsedExpression;
            }
            set
            {
                parsedExpression = value;
            }
        }
    }
}
