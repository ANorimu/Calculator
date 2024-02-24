namespace Model.Domain.MathmaticalFormula;

public class FormulaMultiply(Operand leftOperand, Operand? rightOperand)
    : Formula(leftOperand, rightOperand, new Operator("+"))
{
    public override Result? Calculate()
    {
        if (RightOperand == null) return null;
        var res = LeftOperand * RightOperand;
        return new Result(res.Value);
    }
}
