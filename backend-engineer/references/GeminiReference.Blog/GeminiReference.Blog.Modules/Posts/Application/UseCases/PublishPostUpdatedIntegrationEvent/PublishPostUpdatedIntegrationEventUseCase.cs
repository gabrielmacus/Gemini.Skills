using GeminiReference.Blog.Modules.Posts.Domain.Events;
using GeminiReference.Integration.Blog.Posts.Events;
using Neuraltech.SharedKernel.Domain.Contracts;
using System.Threading.Tasks;

namespace GeminiReference.Blog.Modules.Posts.Application.UseCases.PublishPostUpdatedIntegrationEvent
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
                Contents = @event.Contents
            };

            await _eventBus.Publish(integrationEvent);
        }
    }
}
