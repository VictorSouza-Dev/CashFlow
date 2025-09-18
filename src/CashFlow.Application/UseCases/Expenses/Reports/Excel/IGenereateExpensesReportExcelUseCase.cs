namespace CashFlow.Application.UseCases.Expenses.Reports.Excel;

public interface IGenereateExpensesReportExcelUseCase
{
    Task<Byte[]> Execute(DateOnly month);
}
