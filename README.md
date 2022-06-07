[![.NET](https://github.com/samjones00/fluent-validation-custom-rule/actions/workflows/dotnet.yml/badge.svg)](https://github.com/samjones00/fluent-validation-custom-rule/actions/workflows/dotnet.yml)

# Fluent Validation Custom Validator

An example of using custom validators with Fluent Validation, this one fails validation if the enum specified in the abstract validator is matched with the one provided.

```csharp

namespace FluentValidationCustomRule.Core.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            // Validate string properties
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();

            // Validate if the address type has been set, or is using the first enum value by default
            RuleFor(x => x.AddressType).IsNot(AddressType.None);
        }
    }
}

```

See https://docs.fluentvalidation.net/en/latest/custom-validators.html for more details.