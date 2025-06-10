using CashFlow.Communication.Enums;
using CashFlow.Communication.Request;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);

        return new ResponseRegisterExpenseJson
        {

        };
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            throw new ArgumentException("Title is required.");
        }

        if (request.Amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }

        var result = DateTime.Compare(request.Date, DateTime.UtcNow);
        if (result > 0)
        {
            throw new ArgumentException("Express");      
        }

        var paymentTyoeIsValid = Enum.IsDefined(typeof(PaymentType), request.PaymentType);
        if (paymentTyoeIsValid == false)
        {
            throw new ArgumentException("Payment type is invalid.");
        }
            
    }
}
