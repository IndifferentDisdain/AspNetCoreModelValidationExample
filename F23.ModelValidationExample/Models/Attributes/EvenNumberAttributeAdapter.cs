using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using System;

namespace F23.ModelValidationExample.Models.Attributes
{
    /// <summary>
    /// Adapter for client side validation for EvenNumberAttribute. Not easily unit tested,
    /// so trust the framework to do what it's supposed to do here.
    /// </summary>
    public class EvenNumberAttributeAdapter : AttributeAdapterBase<EvenNumberAttribute>
    {
        private readonly EvenNumberAttribute _attribute;

        public EvenNumberAttributeAdapter(
            EvenNumberAttribute attribute,
            IStringLocalizer stringLocalizer)
            : base(attribute, stringLocalizer)
        {
            _attribute = attribute;
        }

        public override void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            MergeAttribute(context.Attributes, "data-val-even-number", _attribute.ErrorMessage);
        }

        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
