namespace Calculator.Model.App.Calculate.DTO;

public class CalculateHistoryDTO
{
    public int ID { get; init; }
    public DateTime? At { get; init; }
    public decimal? LeftOperand { get; init; }
    public decimal? RightOperand { get; init; }
    public string? Operator { get; init; }
    public decimal? Result { get; init; }
    public string? Formula { get; init; }
}
