using System;

namespace Core;

public class Result<T>
{
    private readonly T? _value;
    private readonly Error _error;
    private readonly bool _isSuccess;

    public T? Value => _value;

    public Error Error => _error;

    public bool Suceeded => _isSuccess;

    private Result(T value)
    {
        _value = value;
        _error = Error.None;
        _isSuccess = true;
    }
    public Result(Error error)
    {
        _error = error;
        _value = default;
        _isSuccess = false;
    }
    public static Result<T> Success(T value) => new Result<T>(value);
    public static Result<T> Failure(Error error) => new Result<T>(error);

    public static implicit operator Result<T>(T value) => new (value);
    public static implicit operator Result<T>(Error error) => new(error);

    public TResult Match<TResult>(
        Func<T, TResult> success,
        Func<Error, TResult> failure)
    {
        return _isSuccess ? success(_value) : failure(_error);
    }
}
