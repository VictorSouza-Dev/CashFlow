using CashFlow.Domain.Interfaces.Repositories.Expenses;
using CashFlow.Domain.Models;

namespace CashFlow.Application.UseCases.Expenses.FilterMonth;

public class FilterExpensesByMonthUseCase : IFilterExpensesByMonthUseCase
{
    private readonly IExpensesReadOnlyRepository _repository;

    public FilterExpensesByMonthUseCase(IExpensesReadOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Expense>> Execute(DateOnly date)
    {
        var startDate = new DateTime(year: date.Year, month: date.Month, day: 1).Date;

        var daysInMonth = DateTime.DaysInMonth(year: date.Year, month: date.Month);

        var endDate = new DateTime(
            year: date.Year,
            month: date.Month,
            day: daysInMonth,
            hour: 23,
            minute: 59,
            second: 59
        );

        return await _repository.FilterByPeriod(startDate, endDate);
    }
}
