using Calculator.Infrastracture.Database;
using Calculator.Model.App;
using Calculator.Model.App.Calculate;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.View.WinForm.Configuration;

internal class DISetUpper : IDISetupper
{
    public void Setup(IServiceCollection services)
    {
        var sqlConnectionSb = new SqliteConnectionStringBuilder
        {
            //DataSource = ":memory:"
            DataSource = "file:calculatero.db?mode=memory"
        };
        services.AddDbContext<CalculatorDBContext>(options =>
            options.UseSqlite(sqlConnectionSb.ToString()));
        //services.AddDbContext<CalculatorDBContext>(ServiceLifetime.Scoped);
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IQueryFactory, QueryFactory>();
        services.AddTransient<ICalculateService, CalculateService>();
        services.AddTransient<ICalculateHistoryQueryService, CalculateHistoryQueryService>();
    }
}
