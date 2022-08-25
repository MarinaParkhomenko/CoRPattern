namespace Lab5.Models;

public class ValidationHandler : BaseFormHandler
{
    public override Form? Handle(Form form)
    {
        form.IsValidationSucceded = true;
        foreach (var field in form.Fields)
        {
            var isValid = field.IsValid();
            if (!isValid && field.Validator is not null)
            {
                form.IsValidationSucceded = false;
                form.ErrorMessages.AddRange(field.Validator.ValidationMessages);
            }
        }

        if (form.IsValidationSucceded)
            return base.Handle(form);
        
        return form;
    }
}