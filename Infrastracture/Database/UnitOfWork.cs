using Calculator.Infrastracture.Repositories;
using Calculator.Model.App;
using Calculator.Model.Domain.CalculateHistory;

namespace Calculator.Infrastracture.Database;

public class UnitOfWork(CalculatorDBContext DBContext) : IUnitOfWork
{    
    public ICalculateHistoryRepository CalculateHistoryRepository => new CalculateHistoryRepository(DBContext);

    public void Begin()
    {
        DBContext.Database.BeginTransaction();
    }

    public void Commit()
    {
        DBContext.Database.CommitTransaction();
    }

    public void Rollback()
    {
        DBContext.Database.RollbackTransaction();
    }
    private bool disposed = false;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
            return;

        if (disposing)
        {
            DBContext.Dispose();
        }
        disposed = true;
    }
}
