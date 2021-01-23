# AspNetCoreModelValidationExample
This project is a sample ASP.NET Core web application written for demonstration during a Lunch & Learn at feature[23]. This project reviews basic validation, custom validation attributes, and client-side validation without needing a front end framework.

# Getting Started
0. Install ASP.NET Core 3.1.x.
1. Clone
2. Run the web project (no need for any front-end build process)
3. Submit the forms on the homepage, /better, and /best nav links

# Features
## Basic Validation
The most basic validation uses built-in ASP.NET Core `ValidationAttribute` implementations for server-side validation, and POST methods validate `ModelState` before continuing.

## Better Validation
The better validation uses custom `ValidationAttribute` implementations to validate more complex business logic on the server.

## Best Validation
The best validation uses the same custom `ValidationAttribute` implementations as Better. Additionally, through custom `AttributeAdapterBase<T>` implementations and a custom implementation of `ValidationAttributeAdapterProvider`, client-side validation is possible by adding custom `data-*` attributes that are added to the generated HTML when using the default ASP.NET Core tag helpers in Razor views.

## Client Validation Library
In order to validate client-side, a simple JavaScript validation library is included. The solution uses the default Bootstrap 4 validation classes.

## Partial Alert Views
The solution uses a partial view to show model validation errors. A base `Controller` implementation handles setting the validation errors for viewing.

## Unit Testing
Unit testing `ValidationAttribute` implementations is demonstrated in both simple and more complex scenarios. Unit tests focus on testing the logic in the attributes themselves, not how the ASP.NET Core pipeline executes them (trust the framework).
