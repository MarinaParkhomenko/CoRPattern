using Lab5.Models;
using Lab5.Validators;

var validationHandler = new ValidationHandler();
var sqlInjectionHandler = new SqlInjectionHandler();
var xssHandler = new XssHandler();

xssHandler.SetNext(sqlInjectionHandler);
sqlInjectionHandler.SetNext(validationHandler);

Console.Write("First name: ");
var firstName = Console.ReadLine();
Console.Write("Last name: ");
var lastName = Console.ReadLine();
Console.Write("Birth year: ");
var birthYear = Console.ReadLine();

var form = new Form();
form.AddField(new FormField()
{
    FieldName = "First name", 
    Value = firstName,
    Validator = new StringFieldValidator() { MinLength = 2, MaxLength = 50 }
});
form.AddField(new FormField()
{
    FieldName = "Last name", 
    Value = lastName,
    Validator = new StringFieldValidator() { MinLength = 2, MaxLength = 50 }
});
form.AddField(new FormField()
{
    FieldName = "Birth year", 
    Value = birthYear,
    Validator = new IntegerFieldValidator() {MinValue = 1922, MaxValue = 2004}
});

form = xssHandler.Handle(form);
var validationResult = form.IsValidationSucceded ? "Success" : "Fail";
var sqlInjectionResult = form.IsSqlInjectionDetected ? "Detected" : "Not detected";
var xssResult = form.IsXssAttackDeteced ? "Detected" : "Not detected";

Console.WriteLine($"\nRESULTS:\n" +
                  $"\tValidation: {validationResult}\n" +
                  $"\tSQl Injection: {sqlInjectionResult}\n" +
                  $"\tXSS Attack: {xssResult}");
Console.WriteLine("\nError messages:");
form.ErrorMessages.ForEach(message => Console.WriteLine(message));
