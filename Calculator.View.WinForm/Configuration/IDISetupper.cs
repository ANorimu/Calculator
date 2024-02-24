using Microsoft.Extensions.DependencyInjection;

namespace Calculator.View.WinForm.Configuration
{
    internal interface IDISetupper
    {
        void Setup(IServiceCollection services);
    }
}
