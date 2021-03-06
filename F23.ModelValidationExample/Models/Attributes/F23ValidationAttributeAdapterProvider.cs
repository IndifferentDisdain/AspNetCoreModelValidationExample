﻿using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace F23.ModelValidationExample.Models.Attributes
{
    /// <summary>
    /// Adapter provider. This is used in Startup.cs to add the custom
    /// attribute providers for client-side validation.
    /// </summary>
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
                adapter = new EvenNumberAttributeAdapter(
                    (EvenNumberAttribute)attribute, 
                    stringLocalizer);
            else if (attribute is DateNotLessThanAttribute)
                adapter = new DateNotLessThanAttributeAdapter(
                    (DateNotLessThanAttribute)attribute, 
                    stringLocalizer);
            else
                adapter = GetAttributeAdapter(attribute, stringLocalizer);

            return adapter;
        }
    }
}
