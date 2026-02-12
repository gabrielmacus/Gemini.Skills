using GeminiReference.Backoffice.Modules.Posts.Domain.Events;
using Wolverine;

namespace GeminiReference.Backoffice.Modules.Posts.Application.UseCases.PublishPostSnapshot
{
    public class PublishPostSnapshotOnCreated : IWolverineHandler
    {
        private readonly PublishPostSnapshotUseCase _useCase;

        public PublishPostSnapshotOnCreated(PublishPostSnapshotUseCase useCase)
        {
            _useCase = useCase;
        }

        public async Task ConsumeAsync(PostCreatedEvent @event)
        {
            await _useCase.Execute(@event.PostId);
        }
    }
}
