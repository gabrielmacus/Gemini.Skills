using System;
using Neuraltech.SharedKernel.Domain.Base;

namespace GeminiReference.Integration.Blog.Posts.Events
{
    public class PostCreatedIntegrationEvent : IntegrationEvent
    {
        public static string PublicMessageName => "GeminiReference.Blog.Posts.PostCreated";
        public override string MessageName => PublicMessageName;

        public required Guid PostId { get; init; }
        public required string Title { get; init; }
        public required string Contents { get; init; }
    }
}
