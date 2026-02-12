using Neuraltech.SharedKernel.Domain.Exceptions;

namespace GeminiReference.Backoffice.Modules.Posts.Domain.Exceptions
{
    public class InvalidPostTitleLengthException : DomainException
    {
        private InvalidPostTitleLengthException(string message)
            : base(message) { }

        public static InvalidPostTitleLengthException FromLength(int length)
        {
            return new InvalidPostTitleLengthException(
                $"El título debe tener entre 5 y 200 caracteres. Longitud actual: {length}"
            );
        }
    }
}
