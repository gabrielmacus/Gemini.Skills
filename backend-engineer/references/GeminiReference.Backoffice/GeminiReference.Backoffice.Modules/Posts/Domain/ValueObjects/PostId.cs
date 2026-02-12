using Neuraltech.SharedKernel.Domain.ValueObjects;

namespace GeminiReference.Backoffice.Modules.Posts.Domain.ValueObjects
{
    public record PostId(Guid value) : UuidValueObject(value) { }
}
