using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Exception;
using CommomTestUtilities.Requests;
using Shouldly;

namespace Validators.Test.Expenses.Register;

public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
       
        // Act
        var result = validator.Validate(request);

        // Assert
        result.ShouldNotBeNull();
    }

    [Fact]
    public void ErrorTitleIsEmpty()
    {
        // Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Title = string.Empty;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeFalse();
        result.Errors.Count.ShouldBe(1);
        result.Errors[0].ErrorMessage.ShouldBe(ResourceErrorMessages.TITLE_REQUIRE);
    }
}
