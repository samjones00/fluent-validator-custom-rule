using FluentValidation.TestHelper;
using FluentValidationCustomRule.Core.Domain;
using FluentValidationCustomRule.Core.Domain.Models;
using FluentValidationCustomRule.Core.Validators;
using NUnit.Framework;

namespace fluent_validation_custom_rule.Validators;

public class PersonValidatorTests
{
    private PersonValidator _personValidator;

    [SetUp]
    public void Setup()
    {
        _personValidator = new PersonValidator();
    }

    [Test]
    public void PersonValidator_Given_Specified_Value_Should_Fail_Validation()
    {
        // Arrange
        var model = new Person(); // Non nullable AddressType enum will use the first option by default

        // Act
        var result = _personValidator.TestValidate(model);

        // Assert
        result.ShouldHaveValidationErrorFor(person => person.AddressType);
    }

    [TestCase(AddressType.Business)]
    [TestCase(AddressType.Personal)]
    public void PersonValidator_Given_Other_Than_Specified_Value_Should_Fail_Validation(AddressType addressType)
    {
        // Arrange
        var model = new Person
        {
            AddressType = addressType
        };

        // Act
        var result = _personValidator.TestValidate(model);

        // Assert
        result.ShouldNotHaveValidationErrorFor(person => person.AddressType);
    }
}