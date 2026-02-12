using GeminiReference.Backoffice.Modules.Posts.Domain.Contracts;
using GeminiReference.Backoffice.Modules.Posts.Domain.Criteria;
using GeminiReference.Backoffice.Modules.Posts.Domain.Entities;
using GeminiReference.Backoffice.Modules.Posts.Domain.Snapshots;
using Microsoft.Extensions.DependencyInjection;
using Neuraltech.SharedKernel.Infraestructure.Persistence.Cached;
using ZiggyCreatures.Caching.Fusion;

namespace GeminiReference.Backoffice.Modules.Posts.Infraestructure.Services
{
    public class PostCachedRepository
        : BaseCachedRepository<Post, PostCriteria, PostSnapshot>,
            IPostRepository
    {
        public PostCachedRepository(
            [FromKeyedServices("uncached")] IPostRepository repository,
            IFusionCacheProvider cacheProvider
        )
            : base(repository, cacheProvider) { }

        protected override string CacheName => "Backoffice.Posts";
    }
}
