namespace Model.Domain.MathmaticalFormula;

public class FormulaNone(Operand leftOperand)
    : Formula(leftOperand, null, null)
{
    public override Result? Calculate()
    {
        return new Result(LeftOperand.Value);
    }
    public override string ToString()
    {
        return $"{LeftOperand} =";
    }
}
