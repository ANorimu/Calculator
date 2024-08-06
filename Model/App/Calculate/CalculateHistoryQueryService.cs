using Calculator.Model.App.Calculate.Queries;
using Calculator.Model.Domain.CalculateHistory;

namespace Calculator.Model.App.Calculate;

public class CalculateHistoryQueryService(IQueryFactory queryFactory) : ICalculateHistoryQueryService
{
    private readonly IQueryFactory QueryFactory = queryFactory;

    public GetCalculateHistoryResponse GetNextCalculateHistory(GetCalculateHistoryRequest request)
    {
        var dto = QueryFactory.CalculateHistoryDTOQuery.FindNextCalculateData(
            new CalculateHistoryID(request.CalculateHistoryID));
        return new GetCalculateHistoryResponse(dto);
    }

    public GetCalculateHistoryResponse GetPreviousCalculateHistory(GetCalculateHistoryRequest request)
    {
        var dto = QueryFactory.CalculateHistoryDTOQuery.FindPreviousCalculateData(
            new CalculateHistoryID(request.CalculateHistoryID));
        return new GetCalculateHistoryResponse(dto);
    }
}
