using System;

public class DiagonalMatrix<T>
{
    private readonly T[] _data;

    public int Size => _data.Length;

    public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;

    public T this[int i, int j]
    {
        get
        {
            if (!IsCorrect(i) || !IsCorrect(j)) throw new IndexOutOfRangeException("Incorrect index");
            if (i != j) return default(T);
            else return _data[i];
        }
        set
        {
            if (!IsCorrect(i) || !IsCorrect(j)) throw new IndexOutOfRangeException("Incorrect index");
            if (i != j || _data[i].Equals(value)) return;
            else
            {
                var oldElement = _data[i];
                _data[i] = value;
                OnElementChanged(new ElementChangedEventArgs<T>(i, oldElement, _data[i]));
            }
        }
    }

    public DiagonalMatrix(int size)
    {
        if (size < 0)
        {
            throw new ArgumentNullException("Size of matrix can't be less than null");
        }
        else
        {
            _data = new T [size];
        }
    }

    private void OnElementChanged(ElementChangedEventArgs<T> e)
    {
        ElementChanged?.Invoke(this, e);
    }

    private bool IsCorrect(int i) => i >= 0 && i < Size;
}