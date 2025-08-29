using CashFlow.Communication.Responses;
using CashFlow.Domain.Interfaces.Repositories.Expenses;

namespace CashFlow.Application.UseCases.GetAll;

public class GetAllExpenseUseCase : IGetAllExpenseUseCase
{
    private readonly IExpensesRepository _repository;

    public GetAllExpenseUseCase(IExpensesRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResponseExpensesJson> Execute()
    {

    }
}
