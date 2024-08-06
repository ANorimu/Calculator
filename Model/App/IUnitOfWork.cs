using Calculator.Model.Domain.CalculateHistory;

namespace Calculator.Model.App;

public interface IUnitOfWork
{
    ICalculateHistoryRepository CalculateHistoryRepository { get; }
    void Begin();
    void Commit();
    void Rollback();
}
