using System;

public static class DiagonalMatrixHelper
{
    public static DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> a, DiagonalMatrix<T> b, Map<T> func)
    {
        if (a is null) throw new ArgumentNullException("Argument DiagonalMatrix<T> a is null");
        if (b is null) throw new ArgumentNullException("Argument DiagonalMatrix<T> b is null");
        if (func is null) throw new ArgumentNullException("Argument Map<T> func is null");

        if (a.Size < b.Size)
        {
            (a, b) = (b, a);
        }

        DiagonalMatrix<T> data = new DiagonalMatrix<T>(a.Size);

        for (var i = 0; i < b.Size; i++)
        {
            data[i,i] = func(a[i, i], b[i, i]);
        }

        for (var i = b.Size; i < a.Size; i++)
        {
            data[i,i] = a[i, i];
        }

        return data;
    }
}
