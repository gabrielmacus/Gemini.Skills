using GeminiReference.Backoffice.Modules.Posts.Domain.Contracts;
using GeminiReference.Backoffice.Modules.Posts.Domain.Entities;
using Microsoft.Extensions.Logging;
using Neuraltech.SharedKernel.Application.UseCases.Delete;
using Neuraltech.SharedKernel.Domain.Contracts;

namespace GeminiReference.Backoffice.Modules.Posts.Application.UseCases.DeletePost
{
    public class DeletePostUseCase(
        ILogger<DeletePostUseCase> logger,
        IPostRepository findByIdRepository,
        IPostRepository repository,
        IEventBus eventBus,
        IUnitOfWork unitOfWork
    ) : DeleteUseCase<Post>(logger, findByIdRepository, repository, eventBus, unitOfWork) { }
}
