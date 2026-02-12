using GeminiReference.Backoffice.Modules.Posts.Domain.Exceptions;
using Neuraltech.SharedKernel.Domain.Services;
using Neuraltech.SharedKernel.Domain.ValueObjects;

namespace GeminiReference.Backoffice.Modules.Posts.Domain.ValueObjects
{
    public record PostTitle : StringValueObject
    {
        public const int MAX_LENGTH = 200;
        public const int MIN_LENGTH = 5;

        public PostTitle(string value)
            : base(value)
        {
            Ensure.HasMaxLength(
                value,
                MAX_LENGTH,
                () => InvalidPostTitleLengthException.FromLength(value.Length)
            );
            Ensure.HasMinLength(
                value,
                MIN_LENGTH,
                () => InvalidPostTitleLengthException.FromLength(value.Length)
            );
        }
    }
}
