namespace Calculator.Model.Domain.CalculateHistory;

public class CalculateHistoryID : IValueObject
{
    public int Value;
    public CalculateHistoryID() { }
    public CalculateHistoryID(int id) => Value = id;
}
