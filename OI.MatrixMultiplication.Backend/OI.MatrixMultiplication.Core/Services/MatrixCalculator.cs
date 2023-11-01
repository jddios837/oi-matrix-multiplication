namespace OI.MatrixMultiplication.Core.Services;

public class MatrixCalculator
{
    public int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB)
    {
        var rowsA = matrixA.GetLength(0);
        var colsA = matrixA.GetLength(1);
        var colsB = matrixB.GetLength(1);

        if (colsA != matrixB.GetLength(0))
        {
            throw new ArgumentException("Matrix dimensions are not compatible for multiplication");
        }

        var result = new int[rowsA, colsB];

        for (var i = 0; i < rowsA; i++)
        {
            for (var j = 0; j < colsB; j++)
            {
                for (var k = 0; k < colsA; k++)
                {
                    result[i, j] += matrixA[i, k] * matrixB[k, j];
                }
            }
        }

        return result;
    }
}