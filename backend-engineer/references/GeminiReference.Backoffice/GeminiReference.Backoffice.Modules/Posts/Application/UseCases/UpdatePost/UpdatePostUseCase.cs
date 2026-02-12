using GeminiReference.Backoffice.Modules.Posts.Application.UseCases.UpdatePost;
using GeminiReference.Backoffice.Modules.Posts.Domain.Contracts;
using GeminiReference.Backoffice.Modules.Posts.Domain.Entities;
using Microsoft.Extensions.Logging;
using Neuraltech.SharedKernel.Application.UseCases.Update;
using Neuraltech.SharedKernel.Domain.Contracts;

namespace GeminiReference.Backoffice.Modules.Posts.Application.UseCases.UpdatePost
{
    public class UpdatePostUseCase(
        ILogger<UpdatePostUseCase> logger,
        IPostRepository findByIdRepository,
        IPostRepository repository,
        IEventBus eventBus,
        IUnitOfWork unitOfWork
    )
        : UpdateUseCase<UpdatePostDTO, Post>(
            logger,
            findByIdRepository,
            repository,
            eventBus,
            unitOfWork
        )
    {
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
