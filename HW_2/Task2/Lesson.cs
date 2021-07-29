using System;

public abstract class Lesson
{
    private string _description = "";

    public string getDescription()
    {
        return _description;
    }

    public void setDescription(string description)
    {
        _description = description is null ? "" : description;
    }

    public virtual void Display()
    {
        Console.WriteLine(_description);
    }
}