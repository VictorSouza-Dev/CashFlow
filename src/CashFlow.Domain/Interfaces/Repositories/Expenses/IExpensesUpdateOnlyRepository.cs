using CashFlow.Domain.Models;

namespace CashFlow.Domain.Interfaces.Repositories.Expenses;

public interface IExpensesUpdateOnlyRepository
{
    Task<Expense?> GetById(long id);
    void Update(Expense expense);
}
