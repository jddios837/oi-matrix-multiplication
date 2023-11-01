using OI.MatrixMultiplication.Core.Services;

namespace OI.MatrixMultiplication.Code.UnitTests.Services;

public class MatrixCalculatorTests
{
    [Fact]
    public void MatrixMultiplication_ValidMatrices_ReturnsResult()
    {
        // Arrange
        var matrixCalculator = new MatrixCalculator();
        int[,] matrixA = new int[,] { { 1, 2 }, { 3, 4 } };
        int[,] matrixB = new int[,] { { 5, 6 }, { 7, 8 } };

        // Act
        int[,] result = matrixCalculator.MultiplyMatrices(matrixA, matrixB);

        // Assert
        int[,] expectedResult = new int[,] { { 19, 22 }, { 43, 50 } };
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void MatrixMultiplication_InvalidMatrices_ThrowsException()
    {
        // Arrange
        var matrixCalculator = new MatrixCalculator();
        int[,] matrixA = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
        int[,] matrixB = new int[,] { { 7, 8 }, { 9, 10 } }; // Invalid dimensions for multiplication

        // Act & Assert
        Assert.Throws<ArgumentException>(() => matrixCalculator.MultiplyMatrices(matrixA, matrixB));
    }
}