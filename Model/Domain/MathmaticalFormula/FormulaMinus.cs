namespace Model.Domain.MathmaticalFormula;

public class FormulaMinus(Operand leftOperand, Operand? rightOperand)
    : Formula(leftOperand, rightOperand, new Operator("+"))
{
    public override Result? Calculate()
    {
        if (RightOperand == null) return null;
        var res = LeftOperand - RightOperand;
        return new Result(res.Value);
    }
}
