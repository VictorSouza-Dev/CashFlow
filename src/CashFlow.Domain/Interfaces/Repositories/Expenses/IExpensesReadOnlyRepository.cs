using CashFlow.Domain.Models;

namespace CashFlow.Domain.Interfaces.Repositories.Expenses;

public interface IExpensesReadOnlyRepository
{
    Task<List<Expense>> GetAll();
    Task<Expense?> GetById(long id);
    Task<List<Expense>> FilterByPeriod(DateTime startDate, DateTime endDate);
}
