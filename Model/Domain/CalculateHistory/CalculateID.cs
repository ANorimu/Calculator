namespace Model.Domain.CalculateHistory;

public class CalculateID : IValueObject
{
    public int Value;
    public CalculateID() { }
    public CalculateID(int id) => Value = id;
}
