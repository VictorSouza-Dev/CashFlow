using AutoMapper;
using CashFlow.Communication.Request;
using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Users.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IMapper _mapper;
    public RegisterUserUseCase(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
    {
        Validate(request);

        var user = _mapper.Map<Domain.Models.User>(request);

        return new ResponseRegisteredUserJson
        {
            Name = user.Name,
        };
    }

    public void Validate(RequestRegisterUserJson request)
    {
        var result  = new RegisterUserValidator().Validate(request);

        if (result.IsValid == false)
        {
            var errorMessage = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessage);
        }
    }
}
