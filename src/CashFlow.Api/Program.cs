using CashFlow.Api.Filters;
using CashFlow.Api.Middleware;
using CashFlow.Application;
using CashFlow.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(option => option.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAplication();
//DependencyInjectionExtension.AddInfrastructure(builder.Services);
//builder.Services.AddScoped<IExpensesRepository, ExpensesRepository>();//se eu precisar dessa interface, ela vai em devolver uma instancia da classe a direita

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CultureMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
