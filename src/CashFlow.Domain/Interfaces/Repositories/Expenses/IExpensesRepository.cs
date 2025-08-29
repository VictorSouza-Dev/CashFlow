using CashFlow.Domain.Models;

namespace CashFlow.Domain.Interfaces.Repositories.Expenses;

public interface IExpensesRepository
{
    Task Add(Expense expense);
    Task<List<Expense>> GetAll();
}
