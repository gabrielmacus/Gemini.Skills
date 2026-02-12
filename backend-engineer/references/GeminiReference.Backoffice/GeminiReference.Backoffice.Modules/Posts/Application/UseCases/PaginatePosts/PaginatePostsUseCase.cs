using GeminiReference.Backoffice.Modules.Posts.Domain.Contracts;
using GeminiReference.Backoffice.Modules.Posts.Domain.Criteria;
using GeminiReference.Backoffice.Modules.Posts.Domain.Entities;
using Microsoft.Extensions.Logging;
using Neuraltech.SharedKernel.Application.UseCases.Paginate;

namespace GeminiReference.Backoffice.Modules.Posts.Application.UseCases.PaginatePosts
{
    public class PaginatePostsUseCase : PaginateUseCase<Post, PostCriteria>
    {
        public PaginatePostsUseCase(
            ILogger<PaginatePostsUseCase> logger,
            IPostRepository repository
        )
            : base(logger, repository) { }
    }
}
