using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.GetAll;

public interface IGetAllExpenseUseCase
{
    Task<ResponseExpensesJson> Execute();
}
