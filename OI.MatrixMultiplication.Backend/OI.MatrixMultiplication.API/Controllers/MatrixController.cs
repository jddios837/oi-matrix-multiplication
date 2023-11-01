using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OI.MatrixMultiplication.Core.Models;
using OI.MatrixMultiplication.Core.Services;
using OI.MatrixMultiplication.Core.Validations;

namespace OI.MatrixMultiplication.API.Controllers;

[ApiController]
[Route("[controller]")]
public class MatrixController : ControllerBase
{
    private readonly MatrixCalculator matrixCalculator;
    private readonly IValidator<MatrixRequest> validator;

    public MatrixController()
    {
        matrixCalculator = new MatrixCalculator();
        validator = new MatrixRequestValidator();
    }

    [HttpPost("multiply")]
    public IActionResult MultiplyMatrices([FromBody] MatrixRequest request)
    {
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        try
        {
            int[,] matrixA = ConvertToMultidimensional(request.MatrixA);
            int[,] matrixB = ConvertToMultidimensional(request.MatrixB);
            int[,] result = matrixCalculator.MultiplyMatrices(matrixA, matrixB);
            
            var resultAsList = ConvertToListOfLists(result);
            
            return Ok(resultAsList);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    private int[,] ConvertToMultidimensional(int[][] jaggedArray)
    {
        int rows = jaggedArray.Length;
        int cols = jaggedArray[0].Length;
        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = jaggedArray[i][j];
            }
        }

        return result;
    }
    
    private List<List<int>> ConvertToListOfLists(int[,] multidimensionalArray)
    {
        int rows = multidimensionalArray.GetLength(0);
        int cols = multidimensionalArray.GetLength(1);
        var resultList = new List<List<int>>();

        for (int i = 0; i < rows; i++)
        {
            var rowList = new List<int>();
            for (int j = 0; j < cols; j++)
            {
                rowList.Add(multidimensionalArray[i, j]);
            }
            resultList.Add(rowList);
        }

        return resultList;
    }
}