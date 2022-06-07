using FluentValidation;
using FluentValidation.Validators;

public static class PropertyValidators
{
    /// <summary>
    /// Determines whether the specified specified value is the one selected
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="ruleBuilder">The rule builder.</param>
    /// <param name="invalidOption">The invalid option</param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, TProperty> IsNot<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, TProperty invalidOption) where TProperty : Enum
    {
        return ruleBuilder.SetValidator(new EnumIsNotPropertyValidator<T, TProperty>(invalidOption));
    }

    private class EnumIsNotPropertyValidator<T, TProperty> : PropertyValidator<T, TProperty> where TProperty : Enum
    {
        private readonly Type _enumType = typeof(TProperty);
        private readonly TProperty _specifiedValue;

        public EnumIsNotPropertyValidator(TProperty specifiedValue)
        {
            _specifiedValue = specifiedValue;
        }

        public override string Name => "EnumIsNotValidator";

        public override bool IsValid(ValidationContext<T> context, TProperty value)
        {
            var underlyingEnumType = Nullable.GetUnderlyingType(_enumType) ?? _enumType;

            if (!underlyingEnumType.IsEnum)
            {
                return false;
            }

            var enumFields = underlyingEnumType.GetFields().Where(x => x.FieldType == _enumType);
            var valueEnumField = enumFields.FirstOrDefault(x => x.Name == value.ToString());
            var specifiedEnumField = enumFields.FirstOrDefault(x => x.Name == _specifiedValue.ToString());

            return specifiedEnumField != valueEnumField;
        }
    }
}
