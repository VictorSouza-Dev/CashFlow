using AutoMapper;
using CashFlow.Communication.Request;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Models;

namespace CashFlow.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }


    private void RequestToEntity()
    {
        CreateMap<RequestRegisterExpenseJson, Expense>();
    }

    private void EntityToResponse()
    {
        CreateMap<Expense, ResponseRegisterExpenseJson>();
    }
}
