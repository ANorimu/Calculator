namespace Model.Domain.MathmaticalFormula;

/// <summary>
/// 演算子
/// </summary>
/// <param name="sign"></param>
public class Operator(string sign) : IValueObject
{
    public string Sign { get; init; } = sign;

    public override string ToString()
    {
        return Sign;
    }
}
