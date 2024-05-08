using Microsoft.AspNetCore.Mvc;

namespace ResultPatternExample.Domain.ResultPattern
{
    public record Result(bool IsSuccess, Error? Error)
    {
        public bool IsFailure => !IsSuccess;
        public static Result Success() => new(true, null);
        public static Result Failure(Error error) => new(false, error);
        public R Match<R>(Func<R> onSuccess, Func<Error, R> onFailure)
            => IsSuccess switch
            {
                true => onSuccess(),
                false => onFailure(Error!)
            };

        public static implicit operator Result(Error error) => Failure(error);
        public static implicit operator ActionResult(Result result) => result.ToActionResult();
    }

    public record Result<A>(A? Value, Error? Error, bool IsSuccess) : Result(IsSuccess, Error)
    {
        public static Result<A> Success(A value) => new(value, null, true);
        public static new Result<A> Failure(Error error) => new(default, error, false);

        public R Match<R>(Func<A, R> onSuccess, Func<Error, R> onFailure)
            => IsSuccess switch
            {
                true => onSuccess(Value!),
                false => onFailure(Error!)
            };

        public static implicit operator Result<A>(A value) => Success(value);
        public static implicit operator Result<A>(Error error) => Failure(error);
        public static implicit operator ActionResult(Result<A> result) => result.ToActionResult();
    }
}
