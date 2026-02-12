using Neuraltech.SharedKernel.Domain.Base;

namespace GeminiReference.Integration.Backoffice.Posts.Events
{
    public class PostDeletedIntegrationEvent : IntegrationEvent
    {
        public static readonly string PublicMessageName =
            "GeminiReference.Backoffice.Posts.PostDeleted";
        public override string MessageName => PublicMessageName;

        public required Guid PostId { get; init; }
    }
}
