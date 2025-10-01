using CashFlow.Domain.Interfaces.Repositories.User;
using CashFlow.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories;

internal class UsersRepository :  IUserReadOnlyRepository, IUserWriteOnlyRepository
{
    private readonly CashFLowDbContext _dbContext;
    public UsersRepository(CashFLowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(User user)
    {
        var result = await _dbContext.Users.AddAsync(user);
        var test = 1;
    }

    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
        return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email));
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Email.Equals(email));
    }
}
