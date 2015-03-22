using System;
using Ninject;
using Calc;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class ConsoleCalculator: Calculator
    {
        public void Run()
        {
            Console.Write("To exit the calculator enter 'exit'.\n\n");
            Console.Write("Enter expression: ");
            string read = Read();
            while (read != "exit")
            {
                if (read != "")
                {
                    try
                    {
                        Write(Calculate(read));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                Console.Write("Enter expression: ");
                read = Read();
            }
        }

        public static void Write(double res)
        {
            Console.Write("Result: {0}\n\n", res);
        }
        public static string Read()
        {
            return Console.ReadLine();
        }
    }
}
