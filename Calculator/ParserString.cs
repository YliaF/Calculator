using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class ParserString : IParser
    {
        private string parserPattern = @"(\()|(\))|(_)";

        public string ParserPattern
        {
            get { return parserPattern; }
            set { parserPattern = value; }
        }

        public string[] ParseExpression(string inputExpression)
        {
            inputExpression = ProcessingString(inputExpression);
            return Regex.Split(inputExpression, ParserPattern).Where(ch => !string.IsNullOrEmpty(ch)).ToArray();
        }

        public ParserString(IList<string> list)
        {
            CreatePattern(list);
        }

        private void CreatePattern(IList<string> OperatorList)
        {
            foreach (string op in OperatorList)
            {
                if (op != "_")
                    ParserPattern += "|(\\" + op + ")";
            }
        }
        private static string ProcessingString(string inputString)
        {
            return ReplaceUnarOperator(ReplacementByCommas(inputString));
        }
        private static string ReplacementByCommas(string inputString)
        {
            return inputString.Replace(".", ",");
        }
        public static string ReplaceUnarOperator(string src)
        {
            return Regex.Replace(Regex.Replace(src, @"(\(-)", "(_"), @"(\A[-]{1})", "_");
        }
    }
}
