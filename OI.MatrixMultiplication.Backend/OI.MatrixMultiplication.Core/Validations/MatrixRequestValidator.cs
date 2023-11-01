using FluentValidation;
using OI.MatrixMultiplication.Core.Models;

namespace OI.MatrixMultiplication.Core.Validations;

public class MatrixRequestValidator : AbstractValidator<MatrixRequest>
{
    public MatrixRequestValidator()
    {
        RuleFor(x => x.MatrixA).NotNull().WithMessage("MatrixA is required.");

        RuleFor(x => x.MatrixA)
            .Must(matrices => ValidateMatrixDimensions(matrices))
            .WithMessage("MatrixA must have between 1 and 5 rows and columns.");

        RuleFor(x => x.MatrixB).NotNull().WithMessage("MatrixB is required.");

        RuleFor(x => x.MatrixB)
            .Must(matrices => ValidateMatrixDimensions(matrices))
            .WithMessage("MatrixB must have between 1 and 5 rows and columns.");
    }

    private bool ValidateMatrixDimensions(int[][] matrices)
    {
        if (matrices == null || matrices.Length < 1 || matrices.Length > 5)
        {
            return false;
        }

        foreach (var row in matrices)
        {
            if (row == null || row.Length < 1 || row.Length > 5)
            {
                return false;
            }
        }

        return true;
    }
}