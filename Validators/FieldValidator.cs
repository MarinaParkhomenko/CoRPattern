using Lab5.Models;

namespace Lab5.Validators;

public abstract class FieldValidator
{
    private readonly List<string> _validationMessages = new List<string>();

    public IEnumerable<string> ValidationMessages
    {
        get => _validationMessages;
    }

    public void AddValidationMessage(string message)
    {
        _validationMessages.Add(message);
    }

    public abstract bool IsValid(FormField formField);
}