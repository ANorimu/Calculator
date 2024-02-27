namespace Model.Domain.MathmaticalFormula;

public abstract class FormulaBase(
    Operand leftOperand, Operand? rightOperand, Operator? ope) : IEntity
{
    public Operand LeftOperand { get; init; } = leftOperand;
    public Operand? RightOperand { get; init; } = rightOperand;
    public Operator? Operator { get; init; } = ope;
    public abstract Result? Calculate();
    public override string ToString()
    {
        if (RightOperand == null) return $"{LeftOperand} {Operator}";
        return $"{LeftOperand} {Operator} {RightOperand} =";
    }
}
