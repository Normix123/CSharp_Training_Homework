

public class PracticalTask : Lesson
{
    private string _referenceToTask;
    private string _referenceToSolution;

    public string ReferenceToTask
    {
        get => _referenceToTask;
        set => _referenceToTask = value is null ? "" : value;
    }

    public string ReferenceToSolution
    {
        get => _referenceToSolution;
        set => _referenceToSolution = value is null ? "" : value;
    }

    public override void Display()
    {
        base.Display();
        System.Console.WriteLine(_referenceToTask);
        System.Console.WriteLine(_referenceToSolution);
    }
}
