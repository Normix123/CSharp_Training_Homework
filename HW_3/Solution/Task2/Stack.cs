using System;

public class Stack<T> : IStack<T> where T : struct
{
    private int index;
    private readonly T[] massive = new T[500];

    public bool IsEmpty() => index == 0;
    public void Push(T e)
    {
        if (index == massive.Length) throw new StackOverflowException();
        massive[index++] = e;
    }
    public T Pop() => !IsEmpty() ? massive[--index] : throw new ArgumentOutOfRangeException();
    public Stack<T> Clone()
    {
        Stack<T> @new = new Stack<T>();
        for (var i = 0; i < index; i++) 
            @new.Push(massive[i]);
        return @new;
    }
}


