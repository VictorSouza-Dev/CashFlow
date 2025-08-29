using CashFlow.Domain.Interfaces.Repositories.Expenses;
using CashFlow.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories;

internal class ExpensesRepository : IExpensesRepository
{
    private readonly CashFLowDbContext _dbContext;

    public ExpensesRepository(CashFLowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Expense expense)
    {
       await _dbContext.Expenses.AddAsync(expense);

    }

    public async Task<List<Expense>> GetAll()
    {
        return await _dbContext.Expenses.ToListAsync();
    }
}
 