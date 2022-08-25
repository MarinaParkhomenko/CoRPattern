using Lab5.Validators;

namespace Lab5.Models;

public class FormField
{
    public string FieldName { get; set; } = String.Empty;
    public string Value { get; set; } = String.Empty;
    public FieldValidator? Validator { get; set; }

    public bool IsValid()
    {
        return Validator?.IsValid(this) ?? true;
    }
}