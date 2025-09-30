using CashFlow.Domain.Models;

namespace CashFlow.Domain.Secutity.Tokens;

public interface IAcessTokenGenerator
{
    string Generate(User user);
}
