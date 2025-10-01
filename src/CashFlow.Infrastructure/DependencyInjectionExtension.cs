using CashFlow.Domain.Interfaces.Repositories;
using CashFlow.Domain.Interfaces.Repositories.Expenses;
using CashFlow.Domain.Interfaces.Repositories.User;
using CashFlow.Domain.Secutity.Cryptography;
using CashFlow.Domain.Secutity.Tokens;
using CashFlow.Infrastructure.DataAccess;
using CashFlow.Infrastructure.DataAccess.Repositories;
using CashFlow.Infrastructure.Security.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositoriesExpense(services);
        AddRepositoriesUser(services);
        AddToken(services, configuration);

        services.AddScoped<IPasswordEncripter, Security.Cryptography.BCrypt>();
    }

    private static void AddToken(IServiceCollection services, IConfiguration configuration)
    {
        var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
        var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

        services.AddScoped<IAcessTokenGenerator>(config => new JwtTokenGenerator(signingKey!, expirationTimeMinutes));
    }

    private static void AddRepositoriesExpense(IServiceCollection services)
    {
        services.AddScoped<IExpensesReadOnlyRepository, ExpensesRepository>();
        services.AddScoped<IExpensesWriteOnlyRepository, ExpensesRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IExpensesUpdateOnlyRepository, ExpensesRepository>();
    }

    private static void AddRepositoriesUser(IServiceCollection services)
    {
        services.AddScoped<IUserReadOnlyRepository, UsersRepository>();
        services.AddScoped<IUserWriteOnlyRepository, UsersRepository>();
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ConnectionString");
        var version = new Version(8, 0, 43);
        var serverVersion = new MySqlServerVersion(version);

        services.AddDbContext<CashFLowDbContext>(config => config.UseMySql(connectionString, serverVersion));
    }
}
