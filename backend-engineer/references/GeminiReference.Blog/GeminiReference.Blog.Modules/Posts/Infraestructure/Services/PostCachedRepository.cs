using GeminiReference.Blog.Modules.Posts.Domain.Contracts;
using GeminiReference.Blog.Modules.Posts.Domain.Criteria;
using GeminiReference.Blog.Modules.Posts.Domain.Entities;
using GeminiReference.Blog.Modules.Posts.Domain.Snapshots;
using Microsoft.Extensions.DependencyInjection;
using Neuraltech.SharedKernel.Infraestructure.Persistence.Cached;
using ZiggyCreatures.Caching.Fusion;

namespace GeminiReference.Blog.Modules.Posts.Infraestructure.Services
{
    public class PostCachedRepository
        : BaseCachedRepository<Post, PostCriteria, PostPrimitives>,
            IPostRepository
    {
        public PostCachedRepository(
            [FromKeyedServices("uncached")] IPostRepository repository,
            IFusionCacheProvider cacheProvider
        )
            : base(repository, cacheProvider) { }

        protected override string CacheName => "Blog.Posts";
    }
}
