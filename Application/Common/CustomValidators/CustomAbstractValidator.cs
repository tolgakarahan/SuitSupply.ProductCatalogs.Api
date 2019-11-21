using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Common.CustomValidators
{
    public abstract class CustomAbstractValidator<T> : AbstractValidator<T>
    {
        protected override bool PreValidate(ValidationContext<T> context, ValidationResult result)
        {
            var stringProperties = context.InstanceToValidate.GetType()
                .GetProperties().Where(x => x.PropertyType == typeof(string));

            foreach (var stringProperty in stringProperties)
            {
                var value = stringProperty.GetValue(context.InstanceToValidate)?.ToString();
                stringProperty.SetValue(context.InstanceToValidate,
                    string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim());
            }

            return base.PreValidate(context, result);
        }
    }
}
