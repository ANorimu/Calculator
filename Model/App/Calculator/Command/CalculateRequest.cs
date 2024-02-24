namespace Model.App.Calculator.Command;

public class CalculateRequest
{
    public enum OperatorSign
    {
        None,
        Plus,
        Minus,
        Multiply,
        Devide
    }
    public decimal LeftNumber { get; set; } = 0;
    public decimal? RightNumber { get; set; } = 0;
    public OperatorSign Sign { get; set; } = OperatorSign.None;
}
