using GeminiReference.Backoffice.Modules.Posts.Domain.Events;
using Wolverine;

namespace GeminiReference.Backoffice.Modules.Posts.Application.IntegrationEventPublishers.PublishPostCreatedIntegrationEvent
{
    public class PublishIntegrationEventOnPostCreated : IWolverineHandler
    {
        private readonly PublishPostCreatedIntegrationEventUseCase _useCase;

        public PublishIntegrationEventOnPostCreated(
            PublishPostCreatedIntegrationEventUseCase useCase
        )
        {
            _useCase = useCase;
        }

        public async Task ConsumeAsync(PostCreatedEvent @event)
        {
            await _useCase.Execute(@event);
        }
    }
}
