using CashFlow.Communication.Request;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Interfaces.Repositories.Expenses;
using CashFlow.Domain.Models;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase : IRegisterExpenseUseCase
{
    private readonly IExpensesRepository _repository;
    public RegisterExpenseUseCase(IExpensesRepository repository)
    {
        _repository = repository;
    }
    public ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);


        var entity = new Expense
        {
            Amount = request.Amount,
            Date = request.Date,
            Description = request.Description,
            Title = request.Title,
            PaymentType = (Domain.Enums.PaymentType)request.PaymentType
        };

        _repository.add(entity);

        return new ResponseRegisterExpenseJson
        {

        };
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var validator = new RegisterExpenseValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessage = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessage);
        }
    }
}
