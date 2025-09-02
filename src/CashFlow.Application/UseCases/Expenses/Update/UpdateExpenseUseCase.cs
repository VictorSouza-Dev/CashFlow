using AutoMapper;
using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Request;
using CashFlow.Domain.Interfaces.Repositories;
using CashFlow.Domain.Interfaces.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;
using Microsoft.Extensions.Options;

namespace CashFlow.Application.UseCases.Expenses.Update;

public class UpdateExpenseUseCase : IUpdateExpenseUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IExpensesUpdateOnlyRepository _repository;
    public UpdateExpenseUseCase(IUnitOfWork unitOfWork, IMapper mapper, IExpensesUpdateOnlyRepository repository)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _repository = repository;
    }

    public async Task Execute(long id, RequestExpenseJson request)
    {
        Validate(request);

        var expense = await _repository.GetById(id);

        if(expense is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }

        _mapper.Map(request, expense);

        _repository.Update(expense);

        await _unitOfWork.Commit();
    }
    private void Validate(RequestExpenseJson request)
    {
        var validator = new ExpenseValidator();

        var result = validator.Validate(request);

        if(result.IsValid is false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
