using static Model.App.Calculator.Command.CalculateRequest;

namespace Model.App.Calculator.Command;

public class CalculateResponse
{
    public int ID { get; set; }
    public DateTime At { get; set; }
    public decimal LeftNumber { get; set; } = 0;
    public decimal? RightNumber { get; set; } = 0;
    public decimal? Result { get; set; } = 0;
    public OperatorSign Sign { get; set; } = OperatorSign.None;
    public string Formula { get; set; } = string.Empty;
}
