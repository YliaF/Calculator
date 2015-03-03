using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;


namespace ConsoleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Console calculator is run...");
            Console.WriteLine("Enter 'exit' for exit.");
            bool start = true;
            ICalc consoleCalc = new Calc();
            while(start)
            {
                consoleCalc.Calculate(Console.ReadLine());
                Console.WriteLine(consoleCalc.Result);
            }

        }
    }
}
