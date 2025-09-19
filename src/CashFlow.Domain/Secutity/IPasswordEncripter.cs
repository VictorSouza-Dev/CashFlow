namespace CashFlow.Domain.Secutity;

public interface IPasswordEncripter
{
    string Encrypt(string password);
}
