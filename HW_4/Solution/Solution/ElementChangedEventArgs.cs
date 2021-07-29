using System;

public class ElementChangedEventArgs<T> : EventArgs
{
    public int Index { get; }
    public T Old { get; }

    public T New { get; }

    public ElementChangedEventArgs(int index, T old, T @new) => (Index, Old, New) = (index, old, @new);
}

