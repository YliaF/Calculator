using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class ParserString
    {
        private string parserPattern = @"(\()|(\))|(_)";

        public ParserString(List<string> OperatorList, string inputString)
        {
            CreatePattern(OperatorList);
            inputString = ProcessingString(inputString);
            ResultString = Regex.Split(inputString, ParserPattern).Where(ch => !string.IsNullOrEmpty(ch)).ToArray();
        }

        private void CreatePattern(List<string> OperatorList)
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

        private string[] resultString;

        public string[] ResultString
        {
            get { return resultString; }
            set { resultString = value; }
        }

        public string ParserPattern
        {
            get { return parserPattern; }
            set { parserPattern = value; }
        }

        public ParserString(string inputString)
        {
            ResultString = Regex.Split(inputString, ParserPattern).Where(ch => !string.IsNullOrEmpty(ch)).ToArray();
        }
    }
}
