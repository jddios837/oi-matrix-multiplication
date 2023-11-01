using FluentValidation.TestHelper;
using OI.MatrixMultiplication.Core.Models;
using OI.MatrixMultiplication.Core.Validations;

namespace OI.MatrixMultiplication.Code.UnitTests.Validations;

public class MatrixRequestValidatorTests
{
    [Fact]
    public void ValidMatrixRequest_ShouldNotHaveValidationErrors()
    {
        // Arrange
        var validator = new MatrixRequestValidator();
        var request = new MatrixRequest
        {
            MatrixA = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } },
            MatrixB = new int[][] { new int[] { 5, 6 }, new int[] { 7, 8 } }
        };

        // Act
        var result = validator.TestValidate(request);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.MatrixA);
        result.ShouldNotHaveValidationErrorFor(x => x.MatrixB);
    }

    [Fact]
    public void InvalidMatrixRequest_ShouldHaveValidationErrors()
    {
        // Arrange
        var validator = new MatrixRequestValidator();
        var request = new MatrixRequest
        {
            MatrixA = new int[][]
            {
                new int[] { 1, 2, 3 }, 
                new int[] { 4, 5, 6 },
                new int[] { 4, 5, 6 },
                new int[] { 4, 5, 6 },
                new int[] { 4, 5, 6 },
                new int[] { 4, 5, 6 },
                new int[] { 4, 5, 6 },
            },
            MatrixB = new int[][]
            {
                new int[] { 7, 8 }, 
                new int[] { 9, 10 }, 
                new int[] { 11, 12 },
                new int[] { 11, 12 },
                new int[] { 11, 12 },
                new int[] { 11, 12 },
                new int[] { 11, 12 },
            }
        };

        // Act
        var result = validator.TestValidate(request);

        // Assert
        Assert.NotEmpty(result.Errors);
        Assert.Contains(result.Errors, error => error.PropertyName == "MatrixA" && error.ErrorMessage == "MatrixA must have between 1 and 5 rows and columns.");
        Assert.Contains(result.Errors, error => error.PropertyName == "MatrixB" && error.ErrorMessage == "MatrixB must have between 1 and 5 rows and columns.");
    }
}