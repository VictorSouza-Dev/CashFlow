using CashFlow.Communication.Request;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Login;

public interface IDoLoginUserCase
{
    Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request);
}
