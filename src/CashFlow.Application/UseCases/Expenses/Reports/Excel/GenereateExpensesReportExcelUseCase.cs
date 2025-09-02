
using CashFlow.Application.UseCases.Expenses.FilterMonth;
using CashFlow.Domain.Interfaces.Repositories.Expenses;
using CashFlow.Domain.Reports;
using ClosedXML.Excel;

namespace CashFlow.Application.UseCases.Expenses.Reports.Excel;

public class GenereateExpensesReportExcelUseCase : IGenereateExpensesReportExcelUseCase
{
    private readonly IFilterExpensesByMonthUseCase _filterUseCase;

    public GenereateExpensesReportExcelUseCase(IFilterExpensesByMonthUseCase filterUseCase)
    {
        _filterUseCase = filterUseCase;
    }

    public async Task<byte[]> Execute(DateOnly month)
    {
        var expenses = await _filterUseCase.Execute(month);

        if(expenses.Count == 0)
        {
            return new byte[0];
        }

        var workBook = new XLWorkbook();

        workBook.Author = "Vitooooooooooor";
        workBook.Style.Font.FontSize = 12;
        workBook.Style.Font.FontName = "ROBOTO";

        month.ToString("");

        var worksheet = workBook.Worksheets.Add(month.ToString("Y"));

        InsertHeader(worksheet);

        var file = new MemoryStream();
        workBook.SaveAs(file);

        return file.ToArray();
    }

    private void InsertHeader(IXLWorksheet worksheet)
    {
        worksheet.Cell("A1").Value = ResourceReportGenerationMessage.TITLE;
        worksheet.Cell("B1").Value = ResourceReportGenerationMessage.DATE;
        worksheet.Cell("C1").Value = ResourceReportGenerationMessage.PAYMENT_TYPE;
        worksheet.Cell("D1").Value = ResourceReportGenerationMessage.AMOUNT;
        worksheet.Cell("E1").Value = ResourceReportGenerationMessage.DESCRIPTION;

        worksheet.Cells("A1:E1").Style.Font.Bold = true;

        worksheet.Cells("A1:E1").Style.Fill.BackgroundColor = XLColor.FromHtml("#F5C2B6");

        worksheet.Cell("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
    }
}
