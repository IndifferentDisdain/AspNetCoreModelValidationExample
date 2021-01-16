using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace F23.ModelValidationExample.Models.Attributes
{
    public class F23ValidationAttributeAdapterProvider 
        : ValidationAttributeAdapterProvider, IValidationAttributeAdapterProvider
    {
        public F23ValidationAttributeAdapterProvider()
        {
        }

        IAttributeAdapter IValidationAttributeAdapterProvider.GetAttributeAdapter(
            ValidationAttribute attribute, 
            IStringLocalizer stringLocalizer)
        {
            IAttributeAdapter adapter;
            if (attribute is EvenNumberAttribute)
                adapter = new EvenNumberAttributeAdapter((EvenNumberAttribute)attribute, stringLocalizer);
            else
                adapter = base.GetAttributeAdapter(attribute, stringLocalizer);

            return adapter;
        }
    }
}
