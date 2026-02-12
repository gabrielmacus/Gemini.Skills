using Neuraltech.SharedKernel.Domain.Exceptions;

namespace GeminiReference.Backoffice.Modules.Posts.Domain.Exceptions
{
    public class InvalidPostContentsLengthException : DomainException
    {
        private InvalidPostContentsLengthException(string message)
            : base(message) { }

        public static InvalidPostContentsLengthException FromLength(int length)
        {
            return new InvalidPostContentsLengthException(
                $"El contenido debe tener entre 20 y 5000 caracteres. Longitud actual: {length}"
            );
        }
    }
}
