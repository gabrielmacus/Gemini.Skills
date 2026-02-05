using GeminiReference.Blog.Modules.Posts.Domain.Contracts;
using GeminiReference.Blog.Modules.Posts.Domain.Entities;
using Microsoft.Extensions.Logging;
using Neuraltech.SharedKernel.Application.UseCases.Create;
using Neuraltech.SharedKernel.Domain.Contracts;

namespace GeminiReference.Blog.Modules.Posts.Application.UseCases.CreatePost
{
    public sealed class CreatePostUseCase : CreateUseCase<Post>
    {
        public CreatePostUseCase(
            ILogger<CreatePostUseCase> logger, 
            IPostRepository repository, 
            IEventBus eventBus, 
            IUnitOfWork unitOfWork
        ) : base(logger, repository, eventBus, unitOfWork)
        {
        }
    }
}
