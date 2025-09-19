using BCrypt.Net;
using CashFlow.Domain.Interfaces.Repositories;
using CashFlow.Domain.Interfaces.Repositories.Expenses;
using CashFlow.Domain.Secutity;
using CashFlow.Infrastructure.DataAccess;
using CashFlow.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);

        services.AddScoped<IPasswordEncripter, Security.BCrypt>();
    }

    public static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IExpensesReadOnlyRepository, ExpensesRepository>();
        services.AddScoped<IExpensesWriteOnlyRepository, ExpensesRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IExpensesUpdateOnlyRepository, ExpensesRepository>();
    }

    public static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ConnectionString");
        var version = new Version(8, 0, 43);
        var serverVersion = new MySqlServerVersion(version);

        services.AddDbContext<CashFLowDbContext>(config => config.UseMySql(connectionString, serverVersion));
    }
}
