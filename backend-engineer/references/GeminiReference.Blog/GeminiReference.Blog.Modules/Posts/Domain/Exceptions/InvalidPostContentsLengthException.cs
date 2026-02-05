using GeminiReference.Blog.Modules.Posts.Domain.ValueObjects;

namespace GeminiReference.Blog.Modules.Posts.Domain.Exceptions
{
    public class InvalidPostContentsLengthException : Exception
    {
        private InvalidPostContentsLengthException(string message) : base(message)
        {
        }

        public static InvalidPostContentsLengthException FromLength(int length)
        {
            return new InvalidPostContentsLengthException(
                $"Post contents length of {length} is invalid. It must be between {PostTitle.MIN_LENGTH} and {PostTitle.MAX_LENGTH} characters.");
        }

    }
}
