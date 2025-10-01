using CashFlow.Exception;
using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace CashFlow.Application.UseCases.Users;

public class PasswordValidator<T> : PropertyValidator<T, string>
{
    private const string ERROR_MESSAGE_KEY = "ErrorMessage";
    public override string Name => "PasswordValidator";

    protected override string GetDefaultMessageTemplate(string errorCode)
    {
        return $"{{{ERROR_MESSAGE_KEY}}}";
    }

    public override bool IsValid(ValidationContext<T> context, string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            return Fail(context, ResourceErrorMessages.INVALID_PASSWORD);
        }

        if(password.Length < 8)
        {
            return Fail(context, ResourceErrorMessages.INVALID_PASSWORD);
        }

        if(Regex.IsMatch(password, @"[A-Z]+") == false)
        {
            return Fail(context, ResourceErrorMessages.INVALID_PASSWORD);
        }

        if(Regex.IsMatch(password, @"[a-z]+") == false)
        {
            return Fail(context, ResourceErrorMessages.INVALID_PASSWORD);
        }

        if (Regex.IsMatch(password, @"[0-9]+") == false)
        {
            return Fail(context, ResourceErrorMessages.INVALID_PASSWORD);
        }   

        if (Regex.IsMatch(password, @"[\!\?\*\.]+") == false)
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }

        return true;
    }

    private bool Fail(ValidationContext<T> context, string message)
    {
        context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, message);
        return false;
    }
}
