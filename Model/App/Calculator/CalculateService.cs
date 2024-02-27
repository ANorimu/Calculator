using Model.App.Calculator.Command;
using Model.Domain.CalculateHistory;
using Model.Domain.MathmaticalFormula;

namespace Model.App.Calculator;

public class CalculateService : ICalculateService
{
    public CalculateResponse Calculate(CalculateRequest command)
    {
        Operand num1 = new(command.LeftNumber);
        Operand? num2 = command.RightNumber == null ? null : new Operand(command.RightNumber.Value);
        FormulaBase formula = command.Sign switch
        {
            CalculateRequest.OperatorSign.Plus => new FormulaPlus(num1, num2),
            CalculateRequest.OperatorSign.Minus => new FormulaMinus(num1, num2),
            CalculateRequest.OperatorSign.Multiply => new FormulaMultiply(num1, num2),
            CalculateRequest.OperatorSign.Devide => new FormulaDevide(num1, num2),
            CalculateRequest.OperatorSign.None => new FormulaNone(num1),
            _ => throw new NotImplementedException(),
        };

        // 計算処理
        var res = formula.Calculate();
        var history = new CalculateHistory
        {
            At = DateTime.Now,
            Formula = formula,
            Result = res
        };

        // TODO DB保存処理


        return new CalculateResponse
        {
            ID = 0,
            At = history.At.Value,
            LeftNumber = history.Formula.LeftOperand.Value,
            RightNumber = history.Formula?.RightOperand?.Value,
            Result = history.Result?.Value,
            Sign = command.Sign,
            Formula = history.Formula == null ? "" : history.Formula.ToString()
        };
    }
}
