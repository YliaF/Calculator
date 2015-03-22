using System.Linq;
using System.Text.RegularExpressions;

namespace Calc
{
    public class Parser : IParser<string[]>
    {
        private string patternParsing = @"(\()|(\))|(_)";
        private IOperations operations;

        public IOperations Operations
        {
            get { return operations; }
            set { operations = value; }
        }

        public string PatternParsing
        {
            get { return patternParsing; }
            set { patternParsing = value; }
        }

        public Parser(IOperations operations)
        {
            this.Operations = operations;
            CreatePatternParsing();
        }
        private void CreatePatternParsing()
        {
            foreach (string op in this.Operations.OperatorList)
            {
                if (op != "_")
                    PatternParsing += "|(\\" + op + ")";
            }
        }
        public string[] Parse(string inputExpression)
        {
            inputExpression = Preprocessing(inputExpression);
            return Regex.Split(inputExpression, PatternParsing).Where(ch => !string.IsNullOrEmpty(ch)).ToArray();
        }
        private static string Preprocessing(string inputString)
        {
            return ReplaceUnarOperator(ReplacementByCommas(inputString));
        }
        private static string ReplacementByCommas(string inputString)
        {
            return inputString.Replace(".", ",");
        }
        //Заменяет унарный минус в инфиксной записи на знак подчеркивание "_" для постфиксной записи       
        public static string ReplaceUnarOperator(string src)
        {
            return Regex.Replace(Regex.Replace(src, @"(\(-)", "(_"), @"(\A[-]{1})", "_");
        }
    }
}
