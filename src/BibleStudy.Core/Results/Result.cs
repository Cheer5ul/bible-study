using System.Xml.Schema;
using BibleStudy.Core.Results.Errors;

namespace BibleStudy.Core.Results;
using Error =  Error;

public class Result
{
    protected Result(bool isSuccess, List<Error> errors)
    {
        IsSuccess = isSuccess;
        Errors = errors;
    }

    private bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public List<Error> Errors { get; }

    public static Result Success()
    {
        return new Result(true, []);
    }

    public static Result Failures(List<Error> errors)
    {
        return new Result(false, errors);
    }
}

public class Result<T> : Result
{
    public T? Value { get; }

    private Result(T value) : base(true, [])
    {
        Value = value ?? throw new ArgumentNullException(nameof(value));
    }

    private Result(List<Error> errors) : base(false, errors) { }

    public static Result<T> Success(T value) => new Result<T>(value);
    
    // 'new' hides inherited method Result.Failures and creates a new one 
    public new static Result<T> Failures(List<Error> errors) => new Result<T>(errors);
    
}