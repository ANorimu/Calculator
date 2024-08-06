using Calculator.Model.Domain.CalculateHistory;
using System.ComponentModel.DataAnnotations;

namespace Calculator.Infrastracture.Database.Tables
{
    public class CalculateHistories
    {
        public CalculateHistories() { }
        public CalculateHistories(CalculateHistory history)
        {
            At = history.At ?? DateTime.Now;
            LeftOperand = history?.Formula?.LeftOperand.Value;
            RightOperand = history?.Formula?.RightOperand?.Value;
            Operator = history?.Formula?.Operator?.ToString();
        }
        [Key]
        public int ID {  get; set; }
        [DataType(DataType.DateTime)]
        public DateTime At { get; set; }
        public decimal? LeftOperand { get; set; }
        public decimal? RightOperand { get; set; }
        public string? Operator { get; set; }
    }
}
