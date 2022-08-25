namespace Lab5.Models;

public interface IFormHandler
{
    void SetNext(IFormHandler next);
    Form Handle(Form form);
}