namespace CashFlow.Domain.Interfaces.Repositories.User;

public interface IUserWriteOnlyRepository
{
    Task Add(Models.User user);
}
