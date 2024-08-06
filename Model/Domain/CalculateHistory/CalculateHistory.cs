using Calculator.Model.Domain.MathmaticalFormula;

namespace Calculator.Model.Domain.CalculateHistory;

public class CalculateHistory
{
    public CalculateHistory() { }
    public CalculateHistory(CalculateHistoryID id, DateTime at, FormulaBase formula)
    {
        ID = id;
        At = at;
        Formula = formula;
    }
    public CalculateHistoryID? ID { get; set; }
    public DateTime? At { get; set; }
    public FormulaBase? Formula { get; set; }
    public Result? Result { get; set; }
}
