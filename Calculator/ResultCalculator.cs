
namespace Calc
{
    public class ResultCalculator : IResultCalculator<double>
    {
        private double resultCalculator;
        public double Result
        {
            get
            {
                return resultCalculator;
            }
            set
            {
                resultCalculator = value;
            }
        }
    }
}
