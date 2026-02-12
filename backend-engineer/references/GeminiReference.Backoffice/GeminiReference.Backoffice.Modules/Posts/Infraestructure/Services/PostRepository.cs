using GeminiReference.Backoffice.Modules.Posts.Domain.Contracts;
using GeminiReference.Backoffice.Modules.Posts.Domain.Criteria;
using GeminiReference.Backoffice.Modules.Posts.Domain.Entities;
using GeminiReference.Backoffice.Modules.Posts.Infraestructure.Models;
using GeminiReference.Backoffice.Modules.SharedKernel.Infraestructure.Services;
using Neuraltech.SharedKernel.Infraestructure.Persistence.EFCore.Repositories;
using Neuraltech.SharedKernel.Infraestructure.Persistence.EFCore.Services;

namespace GeminiReference.Backoffice.Modules.Posts.Infraestructure.Services
{
    public class PostRepository
        : BaseEFCoreRepository<Post, PostModel, PostCriteria>,
            IPostRepository
    {
        public PostRepository(BackofficeDbContext context)
            : base(context, new LinqCriteriaConverter(), new PostMapper()) { }
    }
}
