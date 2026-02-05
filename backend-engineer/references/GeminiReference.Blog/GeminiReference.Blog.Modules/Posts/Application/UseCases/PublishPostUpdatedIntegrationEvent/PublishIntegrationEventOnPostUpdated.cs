using GeminiReference.Blog.Modules.Posts.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using Wolverine;

namespace GeminiReference.Blog.Modules.Posts.Application.UseCases.PublishPostUpdatedIntegrationEvent
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
