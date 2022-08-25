namespace Lab5.Models;

public class XssHandler : BaseFormHandler
{
    public override Form Handle(Form form)
    {
        var xssAttackDetected = form.Fields
            .Select(f => f.Value)
            .Any(f => f.Contains("<script"));

        if (!xssAttackDetected)
            return base.Handle(form);

        form.IsXssAttackDeteced = true;
        form.ErrorMessages.Add("Xss attack detected. Aborting request.");   
        return form;
    }
}