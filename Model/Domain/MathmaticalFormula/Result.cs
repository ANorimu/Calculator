namespace Model.Domain.MathmaticalFormula;

/// <summary>
/// 演算結果
/// </summary>
/// <param name="value"></param>
public class Result(decimal value) : IValueObject
{
    public decimal Value { get; init; } = value;
    public override string ToString()
    {
        return Value.ToString("0.######");
    }
}
