using GeminiReference.Blog.Modules.Posts.Domain.Contracts;
using GeminiReference.Blog.Modules.Posts.Domain.Entities;
using Microsoft.Extensions.Logging;
using Neuraltech.SharedKernel.Application.UseCases.Delete;
using Neuraltech.SharedKernel.Domain.Contracts;


namespace GeminiReference.Blog.Modules.Posts.Application.UseCases.DeletePost
{
    public sealed class DeletePostUseCase : DeleteUseCase<Post>
    {
        public DeletePostUseCase(
            ILogger<DeletePostUseCase> logger, 
            IPostRepository repository,
            IEventBus eventBus, 
            IUnitOfWork unitOfWork
        ) : base(logger, repository, repository, eventBus, unitOfWork)
        {
        }
    }
}
