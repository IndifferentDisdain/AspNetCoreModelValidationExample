using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F23.ModelValidationExample.Models.Attributes
{
    public class DateNotLessThanAttributeAdapter : AttributeAdapterBase<DateNotLessThanAttribute>
    {
        private readonly DateNotLessThanAttribute _attribute;

        public DateNotLessThanAttributeAdapter(
            DateNotLessThanAttribute attribute,
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

            MergeAttribute(context.Attributes, "data-val-date-not-less-than-target", _attribute.ComparisonProperty);
            MergeAttribute(context.Attributes, "data-val-date-not-less-than", _attribute.ErrorMessage);
        }

        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
