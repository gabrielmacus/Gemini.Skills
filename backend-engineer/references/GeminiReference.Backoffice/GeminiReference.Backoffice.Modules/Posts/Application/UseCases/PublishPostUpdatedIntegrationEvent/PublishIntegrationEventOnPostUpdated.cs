using GeminiReference.Backoffice.Modules.Posts.Domain.Events;
using Wolverine;

namespace GeminiReference.Backoffice.Modules.Posts.Application.UseCases.PublishPostUpdatedIntegrationEvent
{
    public class PublishIntegrationEventOnPostUpdated : IWolverineHandler
    {
        private readonly PublishPostUpdatedIntegrationEventUseCase _useCase;

        public PublishIntegrationEventOnPostUpdated(
            PublishPostUpdatedIntegrationEventUseCase useCase
        )
        {
            _useCase = useCase;
        }

        public async Task ConsumeAsync(PostUpdatedEvent @event)
        {
            await _useCase.Execute(@event);
        }
    }
}
