namespace Lab5.Models;

public class Form
{
    public List<FormField> Fields { get; } = new List<FormField>();

    public bool IsValidationSucceded { get; set; }
    public bool IsSqlInjectionDetected { get; set; }
    public bool IsXssAttackDeteced { get; set; }
    public List<string> ErrorMessages { get; } = new List<string>();

    
    public void AddField(FormField formField)
    {
        Fields.Add(formField);
    }
}