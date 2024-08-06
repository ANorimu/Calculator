using Calculator.Infrastracture.Database;
using Calculator.Infrastracture.Database.Tables;
using Calculator.Model.Domain.CalculateHistory;

namespace Calculator.Infrastracture.Repositories;

public class CalculateHistoryRepository(CalculatorDBContext DBContext) : ICalculateHistoryRepository
{
    public void Save(CalculateHistory history)
    {
        DBContext.Add(new CalculateHistories(history));
        DBContext.SaveChanges();
    }
    public void Clear()
    {
        DBContext.RemoveRange(DBContext.CalculateHistories.Select(x => x));
        DBContext.SaveChanges();
    }
}
