

public class Lecture : Lesson
{
    private string _theme = "";
    public string Theme
    {
        get => _theme;
        set => _theme = value is null ? "": value;
    }

    public override void Display()
    {
        base.Display();
        System.Console.WriteLine(_theme);
    }

}
