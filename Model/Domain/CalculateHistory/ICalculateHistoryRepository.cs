namespace Model.Domain.CalculateHistory;

public interface ICalculateHistoryRepository
{
    public void Save(CalculateHistory history);
    public void Clear();
}
