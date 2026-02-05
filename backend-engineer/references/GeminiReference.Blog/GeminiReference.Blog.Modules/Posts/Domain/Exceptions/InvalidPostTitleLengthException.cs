using GeminiReference.Blog.Modules.Posts.Domain.ValueObjects;

namespace GeminiReference.Blog.Modules.Posts.Domain.Exceptions
{
    public class InvalidPostTitleLengthException : Exception
    {
        private InvalidPostTitleLengthException(string message) : base(message)
        {
        }

        public static InvalidPostTitleLengthException FromLength(int length)
        {
            return new InvalidPostTitleLengthException(
                $"Post title length of {length} is invalid. It must be between {PostTitle.MIN_LENGTH} and {PostTitle.MAX_LENGTH} characters.");
        }
    }
}
