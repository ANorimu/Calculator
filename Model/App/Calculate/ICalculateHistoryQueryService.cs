using Calculator.Model.App.Calculate.Queries;

namespace Calculator.Model.App.Calculate;

public interface ICalculateHistoryQueryService
{
    GetCalculateHistoryResponse GetPreviousCalculateHistory(GetCalculateHistoryRequest request);
    GetCalculateHistoryResponse GetNextCalculateHistory(GetCalculateHistoryRequest request);
}
