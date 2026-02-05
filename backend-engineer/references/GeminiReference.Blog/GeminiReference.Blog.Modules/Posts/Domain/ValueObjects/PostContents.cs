using GeminiReference.Blog.Modules.Posts.Domain.Exceptions;
using Neuraltech.SharedKernel.Domain.Services;
using Neuraltech.SharedKernel.Domain.ValueObjects;


namespace GeminiReference.Blog.Modules.Posts.Domain.ValueObjects
{
    public record PostContents : StringValueObject
    {
        public const int MAX_LENGTH = 5000;
        public const int MIN_LENGTH = 20;
        public PostContents(string value) : base(value)
        {
            Ensure.HasMaxLength(value, MAX_LENGTH, () => InvalidPostContentsLengthException.FromLength(value.Length));
            Ensure.HasMinLength(value, MIN_LENGTH, () => InvalidPostContentsLengthException.FromLength(value.Length));
        }
    }
}
