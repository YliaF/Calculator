
namespace Calc
{
    public interface IParser<T>
    {
        IOperations Operations { get; set; }
        T Parse(string inputExpression);
    }
}
