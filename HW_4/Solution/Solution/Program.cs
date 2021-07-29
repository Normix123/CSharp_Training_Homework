using System;

DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(5);

MatrixTracker<int> matrixTracker = new MatrixTracker<int>(diagonalMatrix);

for (int i = 0; i < 5; i++) 
{
    diagonalMatrix[i,i] = i;
    Console.WriteLine(diagonalMatrix[i, i]);
}

Console.WriteLine();

matrixTracker.Undo();

for (int i = 0; i < 5; i++)
{
    Console.WriteLine(diagonalMatrix[i, i]);
}

Console.WriteLine();

DiagonalMatrix<int> diagonalMatrix2 = new DiagonalMatrix<int>(7);

for (int i = 0; i < diagonalMatrix2.Size; i++)
{
    diagonalMatrix2[i, i] = i;
    Console.WriteLine(diagonalMatrix2[i, i]);
}

Console.WriteLine("Sum of matrix (DiagonalMatrixHelper):");

DiagonalMatrix<int> diagonalMatrix3  = diagonalMatrix2.Add<int>(diagonalMatrix, Transformers.IntAdd);

for (int i = 0; i < diagonalMatrix3.Size; i++)
{
    Console.WriteLine(diagonalMatrix3[i, i]);
}