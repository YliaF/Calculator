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
            Console.WriteLine("Console calculator is run...");
            Console.WriteLine("Enter 'exit' for exit.");
            ICalc consoleCalc = new Calc();
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
                read = ReadExpression();
            }
        }
        public static string ReadExpression()
        {
            return Console.ReadLine(); 
        }
        public static void WriteResult(double res)
        {
            Console.Write(" = {0}\n\n", res);
        }
    }
}
