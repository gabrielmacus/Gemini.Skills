using GeminiReference.Blog.Modules.Posts.Domain.Contracts;
using GeminiReference.Blog.Modules.Posts.Domain.Entities;
using Microsoft.Extensions.Logging;
using Neuraltech.SharedKernel.Application.UseCases.Update;
using Neuraltech.SharedKernel.Domain.Contracts;

namespace GeminiReference.Blog.Modules.Posts.Application.UseCases.UpdatePost
{
    public sealed class UpdatePostUseCase : UpdateUseCase<UpdatePostDTO, Post>
    {
        public UpdatePostUseCase(
            ILogger<UpdatePostUseCase> logger, 
            IPostRepository repository,
            IEventBus eventBus, 
            IUnitOfWork unitOfWork
        ) : base(logger, repository, repository, eventBus, unitOfWork)
        {
        }

        protected override Post Combine(Post entityToUpdate, UpdatePostDTO request)
        {
            entityToUpdate.Update(
                request.Title.GetValueOrDefault(entityToUpdate.Title.Value),
                request.Contents.GetValueOrDefault(entityToUpdate.Contents.Value)
            );

            return entityToUpdate;
        }
    }
}
