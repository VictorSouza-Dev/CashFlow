using CashFlow.Domain.Interfaces.Repositories.Expenses;
using CashFlow.Domain.Models;
using CashFlow.Infrastructure.DataAccess;

namespace CashFlow.Infrastructure.Repositories;

internal class ExpensesRepository : IExpensesRepository
{
    private readonly CashFLowDbContext _dbContext;

    public ExpensesRepository(CashFLowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Expense expense)
    {
        _dbContext.AddAsync(expense);

    }
}
 