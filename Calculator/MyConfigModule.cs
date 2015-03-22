using System.Collections.Generic;
using Ninject.Modules;
using Calc;

namespace Calc
{
    public class MyConfigModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IOperations>().To<Operations>();
            Bind<IParser<string[]>>().To<Parser>();
            Bind<IParsedExpression<string[]>>().To<ParsedExpression>();
            Bind<IPostfix<IList<string>>>().To<Postfix>();
            Bind<IPostfixExpression<IList<string>>>().To<PostfixExpression>();
            Bind<ICalculatorPostfix>().To<CalculatorPostfix>();
            Bind<IResultCalculator<double>>().To<ResultCalculator>();
            
        }
    }
}
