using Calculator.Infrastracture.Queries;
using Calculator.Model.App;
using Calculator.Model.App.Calculate.Queries;

namespace Calculator.Infrastracture.Database;

public class QueryFactory(CalculatorDBContext DBContext) : IQueryFactory
{
    public ICalculateHistoryDTOQuery CalculateHistoryDTOQuery => new CalculateHistoryDTOQuery(DBContext);
}
