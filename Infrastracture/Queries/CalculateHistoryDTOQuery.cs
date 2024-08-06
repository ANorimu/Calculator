using Calculator.Infrastracture.Database;
using Calculator.Infrastracture.Database.Tables;
using Calculator.Model.App.Calculate.DTO;
using Calculator.Model.App.Calculate.Queries;
using Calculator.Model.Domain.CalculateHistory;

namespace Calculator.Infrastracture.Queries;

public class CalculateHistoryDTOQuery(CalculatorDBContext DBContext) : ICalculateHistoryDTOQuery
{
    public CalculateHistoryDTO? FindNextCalculateData(CalculateHistoryID calculateID)
    {
        var record = DBContext.CalculateHistories.Where(x => calculateID.Value < x.ID).OrderBy(x => x.ID).First();
        return CreateCalculateDTO(record);
    }

    public CalculateHistoryDTO? FindPreviousCalculateData(CalculateHistoryID calculateID)
    {
        var record = DBContext.CalculateHistories.Where(x => x.ID < calculateID.Value).OrderByDescending(x => x.ID).First();
        return CreateCalculateDTO(record);
    }
    private static CalculateHistoryDTO? CreateCalculateDTO(CalculateHistories record)
    {
        if (record == null)
            return null;

        return new CalculateHistoryDTO
        {
            ID = record.ID,
            At = record.At,
            LeftOperand = record.LeftOperand,
            RightOperand = record.RightOperand,
            Operator = record.Operator,
        };
    }
}
