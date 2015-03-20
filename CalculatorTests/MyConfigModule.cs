using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Calc;

namespace CalculatorTests
{
    public class MyConfigModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IOperations>().To<OperationsCalculator>();
            this.Bind<IParseString>().To<ParseString>();
            this.Bind<IParsedExpression<string[]>>().To<ParsedExpression>();
            this.Bind<IPostfix>().To<Postfix>();
            this.Bind<IPostfixExpression<IList<string>>>().To<PostfixExpression>();
            this.Bind<ICalculator>().To<Calc>();
            this.Bind<CalculatePostfix>().ToSelf();
            this.Bind<IResultCalculation<double>>().To<ResultCalculation>();
        }
    }
}
