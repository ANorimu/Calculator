using Calculator.Model.App.Calculate.Queries;

namespace Calculator.Model.App;

public interface IQueryFactory
{
    public ICalculateHistoryDTOQuery CalculateHistoryDTOQuery { get; }
}
