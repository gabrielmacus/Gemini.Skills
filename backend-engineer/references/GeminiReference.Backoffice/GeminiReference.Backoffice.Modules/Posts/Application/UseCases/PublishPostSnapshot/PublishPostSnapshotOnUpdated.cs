using GeminiReference.Backoffice.Modules.Posts.Domain.Events;
using Wolverine;

namespace GeminiReference.Backoffice.Modules.Posts.Application.UseCases.PublishPostSnapshot
{
    public class PublishPostSnapshotOnUpdated : IWolverineHandler
    {
        private readonly PublishPostSnapshotUseCase _useCase;

        public PublishPostSnapshotOnUpdated(PublishPostSnapshotUseCase useCase)
        {
            _useCase = useCase;
        }

        public async Task ConsumeAsync(PostUpdatedEvent @event)
        {
            await _useCase.Execute(@event.PostId);
        }
    }
}
