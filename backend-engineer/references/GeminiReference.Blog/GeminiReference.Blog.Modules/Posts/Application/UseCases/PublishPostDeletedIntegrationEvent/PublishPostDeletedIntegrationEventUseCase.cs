using GeminiReference.Blog.Modules.Posts.Domain.Events;
using GeminiReference.Integration.Blog.Posts.Events;
using Neuraltech.SharedKernel.Domain.Contracts;

namespace GeminiReference.Blog.Modules.Posts.Application.UseCases.PublishPostDeletedIntegrationEvent
{
    public class PublishPostDeletedIntegrationEventUseCase
    {
        private readonly IEventBus _eventBus;

        public PublishPostDeletedIntegrationEventUseCase(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Execute(PostDeletedEvent @event)
        {
            var integrationEvent = new PostDeletedIntegrationEvent
            {
                PostId = @event.PostId
            };

            await _eventBus.Publish(integrationEvent);
        }
    }
}
