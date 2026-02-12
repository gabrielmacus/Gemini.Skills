using GeminiReference.Backoffice.Modules.Posts.Domain.Events;
using GeminiReference.Integration.Backoffice.Posts.Events;
using Neuraltech.SharedKernel.Domain.Contracts;

namespace GeminiReference.Backoffice.Modules.Posts.Application.UseCases.PublishPostCreatedIntegrationEvent
{
    public class PublishPostCreatedIntegrationEventUseCase
    {
        private readonly IEventBus _eventBus;

        public PublishPostCreatedIntegrationEventUseCase(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Execute(PostCreatedEvent @event)
        {
            var integrationEvent = new PostCreatedIntegrationEvent
            {
                PostId = @event.PostId,
                Title = @event.Title,
                Contents = @event.Contents,
            };

            await _eventBus.Publish(integrationEvent);
        }
    }
}
