using CashFlow.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess;

internal class CashFLowDbContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Database=cashflowdb;Uid=root;Pwd=Abcde.123";
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 43));

        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
}
