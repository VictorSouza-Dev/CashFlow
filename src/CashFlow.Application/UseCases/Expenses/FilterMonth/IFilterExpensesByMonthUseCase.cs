using CashFlow.Domain.Models;

namespace CashFlow.Application.UseCases.Expenses.FilterMonth;

public interface IFilterExpensesByMonthUseCase
{
    Task<List<Expense>> Execute(DateOnly date);
}
