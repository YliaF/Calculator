using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class OperationsCalculator
    {
        private List<string> operatorList = new List<string>();
        public List<string> OperatorList
        {
            get { GetOperatorList(); return operatorList; }
            set { operatorList = value; }
        }
        public OperationsCalculator()
        {
            GetOperatorList();
        }
        private void GetOperatorList()
        {
            OperatorList = (BinaryOperations.Keys.ToList<string>().Concat(UnaryOperations.Keys.ToList<string>()).ToList<string>());
        }

        public Dictionary<string, int> PriorityOperations = new Dictionary<string, int>
        {
            {"(", 0},
            {")", 0},
            {"+", 1},
            {"-", 1},
            {"*", 2},
            {"/", 2},
            {"_", 100} //унарный минус
        };

        public Dictionary<string, Func<double, double, double>> BinaryOperations = new Dictionary<string, Func<double, double, double>>
        {
            {"+", (a, b) => a + b},
            {"-", (a, b) => a - b},
            {"*", (a, b) => a * b},
            {"/", (a, b) => a / b}
        };
        public Dictionary<string, Func<double, double>> UnaryOperations = new Dictionary<string, Func<double, double>>
        {
            {"_", a => -a}
        };
        public void AddBinaryOperation(string operation, Func<double, double, double> action)
        {

            if (BinaryOperations.ContainsKey(operation))
                throw new ArgumentException(string.Format("Operation {0} already exists", operation), "AddBinaryOperation");
            BinaryOperations.Add(operation, action);
        }
        public void AddUnaryOperation(string operation, Func<double, double> action)
        {

            if (BinaryOperations.ContainsKey(operation))
                throw new ArgumentException(string.Format("Operation {0} already exists", operation), "AddUnaryOperation");
            UnaryOperations.Add(operation, action);
        }
        public void SetPriorityOperations(string operation, int priority)
        {   
            PriorityOperations.Add(operation, priority);
        }
    }
}
