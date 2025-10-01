namespace CashFlow.Domain.Interfaces.Repositories.User;

public interface IUserReadOnlyRepository
{
    Task<bool> ExistActiveUserWithEmail(string email);
    Task<Models.User?> GetUserByEmail(string email);
}
