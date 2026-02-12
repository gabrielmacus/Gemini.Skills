using Neuraltech.SharedKernel.Domain.Base;

namespace GeminiReference.Integration.Backoffice.Posts.Events
{
    public class PostCreatedIntegrationEvent : IntegrationEvent
    {
        public static readonly string PublicMessageName =
            "GeminiReference.Backoffice.Posts.PostCreated";
        public override string MessageName => PublicMessageName;

        public required Guid PostId { get; init; }
        public required string Title { get; init; }
        public required string Contents { get; init; }
    }
}
