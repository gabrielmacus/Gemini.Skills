using GeminiReference.Backoffice.Modules.Posts.Domain.Entities;
using GeminiReference.Backoffice.Modules.Posts.Domain.Events;
using Neuraltech.SharedKernel.Application.SnapshotPublishers;
using Wolverine;

namespace GeminiReference.Backoffice.Modules.Posts.Application.SnapshotPublishers.PublishPostSnapshot
{
    public class PublishPostSnapshotOnDeleted : IWolverineHandler
    {
        private readonly PostSnapshotPublisher _useCase;

        public PublishPostSnapshotOnDeleted(PostSnapshotPublisher useCase)
        {
            _useCase = useCase;
        }

        public async Task ConsumeAsync(PostDeletedEvent @event)
        {
            await _useCase.Execute(new SnapshotPublisherDTO<Post>
            {
                Entity = new Post(@event.PostId, @event.Title, @event.Contents),
                MarkAsDeleted = true
            });
        }
    }
}
