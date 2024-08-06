using Calculator.Model.App.Calculate.Command;
using Calculator.Model.Domain.CalculateHistory;
using Calculator.Model.Domain.MathmaticalFormula;

namespace Calculator.Model.App.Calculate;

public class CalculateService(IUnitOfWork unitOfWork) : ICalculateService
{
    private readonly IUnitOfWork UnitOfWork = unitOfWork;

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

        // DB保存処理
        try
        {
            UnitOfWork.Begin();
            UnitOfWork.CalculateHistoryRepository.Save(history);
            UnitOfWork.Commit();
        }
        catch
        {
            UnitOfWork.Rollback();
            // TODO エラー処理
        }
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
