using Calculator.Infrastracture.Database.Tables;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Infrastracture.Database;

public class CalculatorDBContext(DbContextOptions Options) : DbContext(Options)
{
    public DbSet<CalculateHistories> CalculateHistories { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        using (var context = new CalculatorDBContext(Options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
