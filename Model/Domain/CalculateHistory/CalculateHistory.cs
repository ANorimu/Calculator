using Model.Domain.MathmaticalFormula;

namespace Model.Domain.CalculateHistory;

public class CalculateHistory
{
    public CalculateHistory() { }
    public CalculateHistory(CalculateID id, DateTime at, Formula formula)
    {
        ID = id;
        At = at;
        Formula = formula;
    }
    public CalculateID? ID { get; set; }
    public DateTime? At { get; set; }
    public Formula? Formula { get; set; }
    public Result? Result { get; set; }
}
