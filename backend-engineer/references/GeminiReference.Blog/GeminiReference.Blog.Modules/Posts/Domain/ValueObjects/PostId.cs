using Neuraltech.SharedKernel.Domain.ValueObjects;

namespace GeminiReference.Blog.Modules.Posts.Domain.ValueObjects
{
    public record PostId : UuidValueObject
    {
        public PostId(Guid value) : base(value)
        {
        }
    }
}
