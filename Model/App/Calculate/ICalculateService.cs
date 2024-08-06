using Calculator.Model.App.Calculate.Command;

namespace Calculator.Model.App.Calculate
{
    public interface ICalculateService
    {
        CalculateResponse Calculate(CalculateRequest request);
    }
}
