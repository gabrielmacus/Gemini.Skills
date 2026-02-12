using Neuraltech.SharedKernel.Domain.Base;

namespace GeminiReference.Backoffice.Modules.Posts.Domain.Events
{
    public class PostCreatedEvent : BaseEvent
    {
        public required Guid PostId { get; init; }
        public required string Title { get; init; }
        public required string Contents { get; init; }
    }
}
