namespace Lab5.Models;

public class SqlInjectionHandler : BaseFormHandler
{
    public override Form? Handle(Form form)
    {
        var sqlInjectionDetected = form.Fields.Select(f => f.Value.ToUpper())
            .Any(f => f.Contains("SELECT ") 
                      || f.Contains("UPDATE ") 
                      || f.Contains("DELETE ") 
                      || f.Contains("INSERT ") 
                      || f.Contains("DROP "));

        if (!sqlInjectionDetected)
            return base.Handle(form);

        form.IsSqlInjectionDetected = true;
        form.ErrorMessages.Add("Sql injection detected. Aborting request.");
        return form;
    }
}