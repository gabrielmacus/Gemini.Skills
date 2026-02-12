using GeminiReference.Blog.Modules.Posts.Domain.ValueObjects;
using Neuraltech.SharedKernel.Domain.Exceptions;

namespace GeminiReference.Blog.Modules.Posts.Domain.Exceptions
{
    public class InvalidPostContentsLengthException : DomainException
    {
        private InvalidPostContentsLengthException(string message)
            : base(message) { }

        public static InvalidPostContentsLengthException FromLength(int length)
        {
            return new InvalidPostContentsLengthException(
                $"Post contents length of {length} is invalid. It must be between {PostContents.MIN_LENGTH} and {PostContents.MAX_LENGTH} characters."
            );
        }
    }
}
