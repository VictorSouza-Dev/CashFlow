namespace CashFlow.Domain.Secutity.Cryptography;

public interface IPasswordEncripter
{
    string Encrypt(string password);
    bool Verify(string password, string hashedPassword);
}
