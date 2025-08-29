using Bogus;
using CashFlow.Communication.Request;

namespace CommomTestUtilities.Requests;

public class RequestRegisterExpenseJsonBuilder
{
    public static RequestRegisterExpenseJson Build()
    {
        return new Faker<RequestRegisterExpenseJson>()
            .RuleFor(x => x.Title, faker => faker.Commerce.ProductName())
            .RuleFor(x => x.Description, faker => faker.Commerce.ProductDescription())
            .RuleFor(x => x.Date, faker => faker.Date.Past(1))
            .RuleFor(x => x.Amount, faker => faker.Random.Decimal(min: 1, max: 1000))
            .RuleFor(x => x.PaymentType, faker => faker.PickRandom<CashFlow.Communication.Enums.PaymentType>());

    }
}
