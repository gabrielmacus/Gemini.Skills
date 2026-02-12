using GeminiReference.Backoffice.Modules.Posts.Domain.Events;
using Wolverine;

namespace GeminiReference.Backoffice.Modules.Posts.Application.UseCases.PublishPostSnapshot
{
    public class PublishPostSnapshotOnDeleted : IWolverineHandler
    {
        private readonly PublishPostSnapshotUseCase _useCase;

        public PublishPostSnapshotOnDeleted(PublishPostSnapshotUseCase useCase)
        {
            _useCase = useCase;
        }

        public async Task ConsumeAsync(PostDeletedEvent @event)
        {
            await _useCase.Execute(@event.PostId);
        }
    }
}
