using GeminiReference.Blog.Modules.Posts.Domain.Contracts;
using GeminiReference.Blog.Modules.Posts.Domain.Criteria;
using GeminiReference.Blog.Modules.Posts.Domain.Entities;
using GeminiReference.Blog.Modules.Posts.Infraestructure.Models;
using GeminiReference.Blog.Modules.SharedKernel.Infraestructure.Services;
using Microsoft.EntityFrameworkCore;
using Neuraltech.SharedKernel.Infraestructure.Persistence.Contracts;
using Neuraltech.SharedKernel.Infraestructure.Persistence.EFCore.Repositories;
using Neuraltech.SharedKernel.Infraestructure.Persistence.EFCore.Services;

namespace GeminiReference.Blog.Modules.Posts.Infraestructure.Services
{
    public class PostRepository : BaseEFCoreRepository<Post, PostModel, PostCriteria>, IPostRepository
    {
        public PostRepository(
            BlogDbContext context
        ) : base(
            context, 
            new LinqCriteriaConverter(),
            new PostMapper()
        )
        {
        }
    }
}
