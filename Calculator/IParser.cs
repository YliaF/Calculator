
namespace Calc
{
    public interface IParser<T>
    {
        T Parse(string inputExpression);
    }
}
