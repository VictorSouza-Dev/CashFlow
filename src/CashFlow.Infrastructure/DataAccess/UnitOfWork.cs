using CashFlow.Domain.Interfaces.Repositories;

namespace CashFlow.Infrastructure.DataAccess;

internal class UnitOfWork : IUnitOfWork
{
    private readonly CashFLowDbContext _dbContext;
    public UnitOfWork(CashFLowDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Commit()
    {
       _dbContext.SaveChangesAsync();
    }
}
