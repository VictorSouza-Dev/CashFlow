using CashFlow.Domain.Models;

namespace CashFlow.Domain.Interfaces.Repositories.Expenses;

public interface IExpensesRepository
{
    void add(Expense expense);
}
