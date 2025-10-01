using CashFlow.Domain.Secutity.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace CashFlow.Infrastructure.Security.Cryptography;

public class BCrypt : IPasswordEncripter
{
    public string Encrypt(string password)
    {
        string passwordHash = BC.HashPassword(password);

        return passwordHash;
    }
    public bool Verify(string password, string hashedPassword)
    {
        return BC.Verify(password, hashedPassword);
    }
}
