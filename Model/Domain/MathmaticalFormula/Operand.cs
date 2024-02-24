namespace Model.Domain.MathmaticalFormula;

/// <summary>
/// 被演算子となる数値
/// </summary>
/// <param name="value"></param>
public class Operand(decimal value) : IValueObject
{
    public decimal Value { get; init; } = value;
    public static Operand operator +(Operand a)
        => a;

    public static Operand operator -(Operand a)
        => new(-a.Value);

    public static Operand operator +(Operand a, Operand b)
        => new(a.Value + b.Value);

    public static Operand operator -(Operand a, Operand b)
        => a + -b;

    public static Operand operator *(Operand a, Operand b)
        => new(a.Value * b.Value);

    public static Operand operator /(Operand a, Operand b)
    {
        return new(a.Value / b.Value);
    }
    public override string ToString()
    {
        return Value.ToString("0.######");
    }
}
