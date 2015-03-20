
namespace Calc
{
    public interface IPostfix<T>
    {
        T ConvertToPostfix(IParsedExpression<string[]> parsedExpression);

        void ConvertToPostfix(IParsedExpression<string[]> parsedExpression, IPostfixExpression<T> postfixExpression);
    }
}
