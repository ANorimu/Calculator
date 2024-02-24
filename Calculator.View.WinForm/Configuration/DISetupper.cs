using Microsoft.Extensions.DependencyInjection;
using Model.App.Calculator;

namespace Calculator.View.WinForm.Configuration
{
    internal class DISetUpper : IDISetupper
    {
        public void Setup(IServiceCollection services)
        {
            // TODO DBContext追加
            services.AddTransient<ICalculateService, CalculateService>();
        }
    }
}
