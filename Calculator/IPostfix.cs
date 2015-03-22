
namespace Calc
{
    public interface IPostfix<T>
    {
        T ConvertToPostfix(IParsedExpression<string[]> parsedExpression);

        IOperations Operations { get; set; }
    }
}
