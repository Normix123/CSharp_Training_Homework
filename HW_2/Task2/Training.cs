using System;
public class Training : Lesson
{
    private object[] _lecturesAndPracticalTasks;
    private int _size;
    public int Size
    {
        get => _size;
    }
    public Training()
    {
        _lecturesAndPracticalTasks = new object[0];
        _size = 0;
    }

    public Training(params object[] lecturesAndPracticalTasks)
    {
        _lecturesAndPracticalTasks = lecturesAndPracticalTasks is null ? new object[0] : new object[lecturesAndPracticalTasks.Length];
        Array.Copy(lecturesAndPracticalTasks, _lecturesAndPracticalTasks, lecturesAndPracticalTasks.Length);
        _size = _lecturesAndPracticalTasks.Length;
    }

    public object this[int i]
    {
        get
        {
            if (i >= Size || i < 0) return 0;
            else return _lecturesAndPracticalTasks[i];
        }
    }
    public void Add(object o)
    {
        object[] newlecturesAndPracticalTasks = new object[_size + 1];
        Array.Copy(_lecturesAndPracticalTasks, newlecturesAndPracticalTasks, _size);
        newlecturesAndPracticalTasks[_size] = o;
        _lecturesAndPracticalTasks = newlecturesAndPracticalTasks;
        _size++;
    }

    public bool isPractical()
    {
        if (_size == 0) return false;
        foreach(var value in _lecturesAndPracticalTasks)
        {
            if (value is Lecture) return false;
        }
        return true;
    }

    public Training Clone()
    {
        object[] toClone = new object[_size];
        Array.Copy(_lecturesAndPracticalTasks, toClone, _size);
        Training training = new Training(toClone);
        training.setDescription(getDescription());
        return training;
    }
}

