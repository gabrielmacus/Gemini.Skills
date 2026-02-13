using GeminiReference.Backoffice.Modules.Posts.Domain.Events;
using Wolverine;

namespace GeminiReference.Backoffice.Modules.Posts.Application.IntegrationEventPublishers.PublishPostDeletedIntegrationEvent
{
    public class PublishIntegrationEventOnPostDeleted : IWolverineHandler
    {
        private readonly PublishPostDeletedIntegrationEventUseCase _useCase;

        public PublishIntegrationEventOnPostDeleted(
            PublishPostDeletedIntegrationEventUseCase useCase
        )
        {
            _useCase = useCase;
        }

        public async Task ConsumeAsync(PostDeletedEvent @event)
        {
            await _useCase.Execute(@event);
        }
    }
}
