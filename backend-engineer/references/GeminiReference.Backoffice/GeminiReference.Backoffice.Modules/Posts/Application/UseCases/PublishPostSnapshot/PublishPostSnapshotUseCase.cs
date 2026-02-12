using GeminiReference.Backoffice.Modules.Posts.Domain.Contracts;
using GeminiReference.Backoffice.Modules.Posts.Domain.Entities;
using GeminiReference.Backoffice.Modules.Posts.Domain.Snapshots;
using GeminiReference.Integration.Backoffice.Posts.Snapshots;
using Microsoft.Extensions.Logging;
using Neuraltech.SharedKernel.Application.UseCases.PublishSnapshot;
using Neuraltech.SharedKernel.Domain.Contracts;

namespace GeminiReference.Backoffice.Modules.Posts.Application.UseCases.PublishPostSnapshot
{
    public class PublishPostSnapshotUseCase
        : PublishSnapshotUseCase<
            Post,
            PostSnapshot,
            PostPublicSnapshot
        >
    {
        public PublishPostSnapshotUseCase(
            IPostRepository repository,
            ISnapshotPublisher snapshotPublisher,
            ILogger<PublishPostSnapshotUseCase> logger
        )
            : base(repository, snapshotPublisher, logger) { }

        protected override PostPublicSnapshot MapSnapshot(
            PostSnapshot snapshot
        )
        {
            return new PostPublicSnapshot
            {
                Id = snapshot.Id,
                Title = snapshot.Title,
                Contents = snapshot.Contents,
            };
        }
    }
}
