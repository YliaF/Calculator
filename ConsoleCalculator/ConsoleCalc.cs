using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;

namespace ConsoleCalculator
{
    public class ConsoleCalc
    {
        public void Run()
        {
            Console.Write("To exit the calculator enter 'exit'.\n\n");
            ICalc consoleCalc = new Calc();
            Console.Write("Enter expression: ");
            string read = ReadExpression();
            while (read != "exit")
            {
                if (read != "")
                {
                    try
                    {
                        consoleCalc.Calculate(read);
                        WriteResult(consoleCalc.Result);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message,e);
                    }
                }
                Console.Write("Enter expression: ");
                read = ReadExpression();
            }
        }
        public static string ReadExpression()
        {
            return Console.ReadLine(); 
        }
        public static void WriteResult(double res)
        {
            Console.Write("Result: {0}\n\n", res);
        }
    }
}
