using Calculator.Model.App.Calculate.DTO;

namespace Calculator.Model.App.Calculate.Queries;

public class GetCalculateHistoryResponse(CalculateHistoryDTO? calculateHistoryDTO)
{
    public CalculateHistoryDTO? CalculateHistoryDTO { get; set; } = calculateHistoryDTO;
}
