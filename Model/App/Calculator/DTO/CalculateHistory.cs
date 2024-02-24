namespace Model.App.Calculator.DTO;

public class CalculateHistory
{
    public int ID { get; set; }
    public DateTime At {  get; set; }
    public decimal LeftNumber { get; set; } = 0;
    public decimal RightNumber { get; set; } = 0;
    public decimal Result { get; set; } = 0;
    public string Sign { get; set; } = string.Empty;
    public string Formula { get; set; } = string.Empty;
}
