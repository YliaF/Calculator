using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;

namespace ConsoleCalculator
{
    class Program
    {
        public static void WriteResult(double res)
        {
            Console.Write("Result: {0}\n\n", res);
        }
        static void Main(string[] args)
        {
            Console.Write("To exit the calculator enter 'exit'.\n\n");
            ICalc consoleCalc = new Calc();
            Console.Write("Enter expression: ");
            string read = Console.ReadLine();
            while (read != "exit")
            {
                if (read != "")
                {
                    try
                    {
                        consoleCalc.Calculate(read);
                        WriteResult(consoleCalc.Result);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                Console.Write("Enter expression: ");
                read = Console.ReadLine();
            }
        }
    }
}
