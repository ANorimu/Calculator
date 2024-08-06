namespace Calculator.Model.App.Calculate.Queries;

public class GetCalculateHistoryRequest(int calculateHistoryId)
{
    public int CalculateHistoryID { get; init; } = calculateHistoryId;
}
