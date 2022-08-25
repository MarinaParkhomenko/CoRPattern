using Lab5.Models;

namespace Lab5.Validators;

public class StringFieldValidator : FieldValidator
{
    public int MinLength { get; set; } = 0;
    public int MaxLength { get; set; } = Int32.MaxValue;

    public override bool IsValid(FormField formField)
    {
        bool longerEqualMin = formField.Value.Length >= MinLength;
        bool shorterEqualMax = formField.Value.Length <= MaxLength;

        if(!longerEqualMin) 
            AddValidationMessage($"Field {formField.FieldName}. Value can't be shorter than {MinLength}");
        if (!shorterEqualMax)
            AddValidationMessage($"Field {formField.FieldName}. Value can't be longer than {MaxLength}");

        return longerEqualMin && shorterEqualMax;
    }
}