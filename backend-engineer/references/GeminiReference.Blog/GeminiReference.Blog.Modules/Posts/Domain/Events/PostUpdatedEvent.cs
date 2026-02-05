using Neuraltech.SharedKernel.Domain.Base;

namespace GeminiReference.Blog.Modules.Posts.Domain.Events
{
    public class PostUpdatedEvent : BaseEvent
    {
        public required Guid PostId { get; init; }
        public required string Title { get; init; }
        public required string Contents { get; init; }
    }
}
