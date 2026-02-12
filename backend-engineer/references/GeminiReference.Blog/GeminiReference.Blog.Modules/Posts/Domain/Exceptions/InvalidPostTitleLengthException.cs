using GeminiReference.Blog.Modules.Posts.Domain.ValueObjects;
using Neuraltech.SharedKernel.Domain.Exceptions;

namespace GeminiReference.Blog.Modules.Posts.Domain.Exceptions
{
    public class InvalidPostTitleLengthException : DomainException
    {
        private InvalidPostTitleLengthException(string message)
            : base(message) { }

        public static InvalidPostTitleLengthException FromLength(int length)
        {
            return new InvalidPostTitleLengthException(
                $"Post title length of {length} is invalid. It must be between {PostTitle.MIN_LENGTH} and {PostTitle.MAX_LENGTH} characters."
            );
        }
    }
}
