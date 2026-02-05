using System;
using Neuraltech.SharedKernel.Domain.Base;

namespace GeminiReference.Integration.Blog.Posts.Events
{
    public class PostDeletedIntegrationEvent : IntegrationEvent
    {
        public static string PublicMessageName => "GeminiReference.Blog.Posts.PostDeleted";
        public override string MessageName => PublicMessageName;

        public required Guid PostId { get; init; }
    }
}
