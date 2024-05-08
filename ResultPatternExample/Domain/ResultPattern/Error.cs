using System.Text.Json.Serialization;

namespace ResultPatternExample.Domain.ResultPattern
{
    public record Error(string Message, ErrorType Type)
    {
        public static Error InvalidArgument(string message)
            => new(message, ErrorType.IncorrectArgument);

        public static Error NotFound(string message)
            => new(message, ErrorType.NotFound);

        public static Error NullOrEmpty(string argumentName)
            => InvalidArgument($"Argumento {argumentName} não pode ser nullo ou vazio!");

        public static Error OnlyNumbersAccepted(string argumentName)
            => InvalidArgument($"Argumento {argumentName} deve conter somente números!");

        public static Error ProductNotFound(string productId)
            => NotFound($"Produto {productId} não encontrado!");
    }

    public record ErrorResponse
    {
        public ErrorResponse(Error error)
        {
            ArgumentNullException.ThrowIfNull(error);

            Message = error.Message;
            Type = error.Type;
        }

        public string Message { get; set; }

        public ErrorType Type { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ErrorType TypeDescription => Type;

        public static explicit operator ErrorResponse(Error error)
            => new(error: error);
    }

    public enum ErrorType
    {
        IncorrectArgument,
        NotFound
    }
}
