using FluentValidation;
using FluentValidationCustomRule.Core.Domain;
using FluentValidationCustomRule.Core.Domain.Models;

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
