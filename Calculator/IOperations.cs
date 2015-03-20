using System;
using System.Collections.Generic;

namespace Calc
{
    public interface IOperations
    {
        IList<string> OperatorList { get; set; }

        Dictionary<string, int> PriorityOperations { get; set; }

        Dictionary<string, Func<double, double, double>> BinaryOperations { get; set; }

        Dictionary<string, Func<double, double>> UnaryOperations { get; set; }

        void AddBinaryOperation(string operation, Func<double, double, double> action);

        void AddUnaryOperation(string operation, Func<double, double> action);

        void SetPriorityOperations(string operation, int priority);
    }
}
