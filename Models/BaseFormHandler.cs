using Lab5.Models;

public abstract class BaseFormHandler : IFormHandler
{
    protected IFormHandler _next;

    public void SetNext(IFormHandler next)
    {
        _next = next;
    }

    public virtual Form Handle(Form form)
    {
        return _next?.Handle(form) ?? form;
    }
}