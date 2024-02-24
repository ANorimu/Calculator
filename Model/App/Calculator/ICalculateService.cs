using Model.App.Calculator.Command;

namespace Model.App.Calculator
{
    public interface ICalculateService
    {
        CalculateResponse Calculate(CalculateRequest request);
    }
}
