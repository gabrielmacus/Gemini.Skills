using Neuraltech.SharedKernel.Domain.Base;

namespace GeminiReference.Backoffice.Modules.Posts.Domain.Events
{
    public class PostDeletedEvent : BaseEvent
    {
        public required Guid PostId { get; init; }
    }
}
