using Calculator.Model.App.Calculate.DTO;
using Calculator.Model.Domain.CalculateHistory;

namespace Calculator.Model.App.Calculate.Queries;

public interface ICalculateHistoryDTOQuery
{
    CalculateHistoryDTO? FindPreviousCalculateData(CalculateHistoryID calculateID);
    CalculateHistoryDTO? FindNextCalculateData(CalculateHistoryID calculateID);
}
