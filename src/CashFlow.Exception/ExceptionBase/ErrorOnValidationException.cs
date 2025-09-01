using System.Net;

namespace CashFlow.Exception.ExceptionBase;

public class ErrorOnValidationException : CashFlowException
{
    private  readonly List<string> _Errors;

    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public ErrorOnValidationException(List<string> errorMesages) : base(string.Empty)
    {
        _Errors = errorMesages;
    }

    public override List<string> GetErrors()
    {
       return _Errors;
    }
}
