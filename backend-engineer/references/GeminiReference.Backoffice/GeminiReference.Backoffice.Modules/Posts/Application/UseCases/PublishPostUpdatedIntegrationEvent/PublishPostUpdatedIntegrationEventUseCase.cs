using GeminiReference.Backoffice.Modules.Posts.Domain.Events;
using GeminiReference.Integration.Backoffice.Posts.Events;
using Neuraltech.SharedKernel.Domain.Contracts;

namespace GeminiReference.Backoffice.Modules.Posts.Application.UseCases.PublishPostUpdatedIntegrationEvent
{
    public class PublishPostUpdatedIntegrationEventUseCase
    {
        private readonly IEventBus _eventBus;

        public PublishPostUpdatedIntegrationEventUseCase(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Execute(PostUpdatedEvent @event)
        {
            var integrationEvent = new PostUpdatedIntegrationEvent
            {
                PostId = @event.PostId,
                Title = @event.Title,
                Contents = @event.Contents,
            };

            await _eventBus.Publish(integrationEvent);
        }
    }
}
