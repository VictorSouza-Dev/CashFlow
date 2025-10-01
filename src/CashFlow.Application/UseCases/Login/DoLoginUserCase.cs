using CashFlow.Communication.Request;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Interfaces.Repositories.User;
using CashFlow.Domain.Secutity.Cryptography;
using CashFlow.Domain.Secutity.Tokens;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Login;

public class DoLoginUserCase : IDoLoginUserCase
{
    private readonly IUserReadOnlyRepository _repository;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly IAcessTokenGenerator _tokenGenerator;

    public DoLoginUserCase(
        IAcessTokenGenerator tokenGenerator, 
        IPasswordEncripter passwordEncripter, 
        IUserReadOnlyRepository repository)
    {
        _tokenGenerator = tokenGenerator;
        _passwordEncripter = passwordEncripter;
        _repository = repository;
    }

    public async Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request)
    {
       var user = await _repository.GetUserByEmail(request.Email);
        if (user is null)
        {
            throw new InvalidLoginException();
        }

        var passwordMatch = _passwordEncripter.Verify(request.Password, user.Password);

        if(!passwordMatch)
        {
            throw new InvalidLoginException();
        }
        return new ResponseRegisteredUserJson
        {
            Name = user.Name,
            Token = _tokenGenerator.Generate(user)
        };
    }
}
