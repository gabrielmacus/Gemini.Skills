using GeminiReference.Backoffice.Modules.Posts.Application.UseCases.CreatePost;
using GeminiReference.Backoffice.Modules.Posts.Domain.Contracts;
using GeminiReference.Backoffice.Modules.Posts.Domain.Entities;
using Microsoft.Extensions.Logging;
using Neuraltech.SharedKernel.Application.UseCases.Create;
using Neuraltech.SharedKernel.Domain.Contracts;

namespace GeminiReference.Backoffice.Modules.Posts.Application.UseCases.CreatePost
{
    public class CreatePostUseCase(
        ILogger<CreatePostUseCase> logger,
        IPostRepository repository,
        IEventBus eventBus,
        IUnitOfWork unitOfWork
    ) : CreateUseCase<CreatePostDTO, Post>(logger, repository, eventBus, unitOfWork)
    {
        protected override ValueTask<Post> ProcessRequest(CreatePostDTO request)
        {
            return ValueTask.FromResult(Post.Create(request.Id, request.Title, request.Contents));
        }
    }
}
