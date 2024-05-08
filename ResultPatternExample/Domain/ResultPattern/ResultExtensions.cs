using Microsoft.AspNetCore.Mvc;

namespace ResultPatternExample.Domain.ResultPattern
{
    public static class ResultExtensions
    {
        private static ActionResult HandleSuccess() => new NoContentResult();
        private static ActionResult HandleSuccess<T>(this T value)
        {
            if (value is null)
                return HandleSuccess();

            return new OkObjectResult(value);
        }
        private static ActionResult HandleError(this Error error)
        {
            ArgumentNullException.ThrowIfNull(error);

            return error.Type switch
            {
                ErrorType.IncorrectArgument => new BadRequestObjectResult((ErrorResponse)error),
                ErrorType.NotFound => new NotFoundObjectResult((ErrorResponse)error),
                _ => throw new InvalidOperationException("Não foi possível executar a função")
            };
        }

        public static ActionResult ToActionResult(this Result result)
        {
            return result.Match(
                onSuccess: HandleSuccess,
                onFailure: HandleError);
        }

        public static ActionResult ToActionResult<A>(this Result<A> result)
        {
            return result.Match(
                onSuccess: HandleSuccess,
                onFailure: HandleError);
        }
    }
}
