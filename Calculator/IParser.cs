
namespace Calc
{
    public interface IParser<T>
    {
        T Parse(string inputExpression);
        void Parse(string inputExpression, IParsedExpression<T> parsedExpression);
    }
}
