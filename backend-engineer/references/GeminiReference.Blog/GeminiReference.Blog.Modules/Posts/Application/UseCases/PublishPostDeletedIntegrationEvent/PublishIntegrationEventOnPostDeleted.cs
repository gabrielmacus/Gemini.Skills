using GeminiReference.Blog.Modules.Posts.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using Wolverine;

namespace GeminiReference.Blog.Modules.Posts.Application.UseCases.PublishPostDeletedIntegrationEvent
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
