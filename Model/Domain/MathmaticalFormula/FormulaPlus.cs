namespace Model.Domain.MathmaticalFormula;

public class FormulaPlus(Operand leftOperand, Operand? rightOperand)
    : FormulaBase(leftOperand, rightOperand, new Operator("+"))
{
    public override Result? Calculate()
    {
        if (RightOperand == null) return null;
        var res = LeftOperand + RightOperand;
        return new Result(res.Value);
    }
}
