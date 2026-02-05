using GeminiReference.Blog.Modules.Posts.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using Wolverine;

namespace GeminiReference.Blog.Modules.Posts.Application.UseCases.PublishPostCreatedIntegrationEvent
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
