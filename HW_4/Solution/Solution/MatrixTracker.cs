using System;

public class MatrixTracker<T> 
{
    private DiagonalMatrix<T> _diagonalMatrix;
    private ElementChangedEventArgs<T> elementChangedEventArgs;

    public MatrixTracker(DiagonalMatrix<T> diagonalMatrix)
    {
        if (diagonalMatrix is null) throw new ArgumentNullException();
        _diagonalMatrix = diagonalMatrix;
        _diagonalMatrix.ElementChanged += (_, e) => elementChangedEventArgs = e;
    }

    public void Undo()
    {
        _diagonalMatrix[elementChangedEventArgs.Index, elementChangedEventArgs.Index] = elementChangedEventArgs.Old;
    }
}

