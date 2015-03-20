﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calc;

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
            ICalculator consoleCalculator = new ConsoleCalculator();
            Console.Write("Enter expression: ");
            string read = Console.ReadLine();
            while (read != "exit")
            {
                if (read != "")
                {
                    try
                    {
                        WriteResult(consoleCalculator.Calculate(read));
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
