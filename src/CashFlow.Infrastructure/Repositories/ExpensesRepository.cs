using CashFlow.Domain.Interfaces.Repositories.Expenses;
using CashFlow.Domain.Models;
using CashFlow.Infrastructure.DataAccess;

namespace CashFlow.Infrastructure.Repositories;

internal class ExpensesRepository : IExpensesRepository
{
    public void add(Expense expense)
    {
        var dbContext = new CashFLowDbContext();

        dbContext.Add(expense);

        dbContext.SaveChanges();
    }
}
