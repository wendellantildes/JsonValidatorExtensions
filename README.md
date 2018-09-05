

### What is JsonValidatorExtensions?

JsonValidatorExtensions is a simple little library built to validate json requests available until now for .NetCore.

### How do I get started?

You just need to add in the Configure method in your Startup class:

```csharp
app.UseJsonValidator();
```
If you want to return a custom response, you can do:

```csharp
app.UseJsonValidator(new InvalidJsonResponseOptions(StatusCodes.Status400BadRequest,
            new { message = "This is json is forbiden"}));
```
