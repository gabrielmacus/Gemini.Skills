using GeminiReference.Backoffice.Modules.Posts.Domain.Entities;
using GeminiReference.Integration.Backoffice.Posts.Snapshots;
using Microsoft.Extensions.Logging;
using Neuraltech.SharedKernel.Application.SnapshotPublishers;
using Neuraltech.SharedKernel.Domain.Contracts;

namespace GeminiReference.Backoffice.Modules.Posts.Application.SnapshotPublishers.PublishPostSnapshot
{
    public class PostSnapshotPublisher
        : SnapshotPublisher<
            Post,
            PostSnapshot
        >
    {
        public PostSnapshotPublisher(
            //IPostRepository repository,
            ISnapshotPublisher snapshotPublisher,
            ILogger<PostSnapshotPublisher> logger
        )
            : base(/*repository,*/ snapshotPublisher, logger) { }

        protected override PostSnapshot MapSnapshot(
            Post entity
        )
        {
            return new PostSnapshot
            {
                PostId = entity.Id.Value,
                Title = entity.Title.Value,
                Contents = entity.Contents.Value
            };
        }
    }
}
