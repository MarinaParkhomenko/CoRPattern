using Lab5.Models;

namespace Lab5.Validators;

public class IntegerFieldValidator : FieldValidator
{
    public int MinValue { get; set; } = Int32.MinValue;
    public int MaxValue { get; set; } = Int32.MaxValue;
    
    public override bool IsValid(FormField formField)
    {
        if (Int32.TryParse(formField.Value, out int value))
        {
            var moreEqualMin = value >= MinValue;
            var lessEqualMax = value <= MaxValue;
            
            if(!moreEqualMin)
                AddValidationMessage($"Field {formField.FieldName}. Value can't be less than {MinValue}");
            if(!lessEqualMax)
                AddValidationMessage($"Field {formField.FieldName}. Value can't be greater than {MaxValue}");

            return moreEqualMin && lessEqualMax;
        }
        AddValidationMessage($"Field {formField.FieldName}. Value is not an integer value");
        return false;
    }
}