using GeminiReference.Blog.Modules.Posts.Domain.Contracts;
using GeminiReference.Blog.Modules.Posts.Domain.Criteria;
using GeminiReference.Blog.Modules.Posts.Domain.Entities;
using GeminiReference.Blog.Modules.Posts.Infraestructure.Models;
using GeminiReference.Blog.Modules.SharedKernel.Infraestructure.Services;
using Neuraltech.SharedKernel.Infraestructure.Persistence.EFCore.Repositories;
using Neuraltech.SharedKernel.Infraestructure.Persistence.EFCore.Services;
using ZiggyCreatures.Caching.Fusion;

namespace GeminiReference.Blog.Modules.Posts.Infraestructure.Services
{
    public class PostRepository
        : CachedEFCoreRepository<Post, PostModel, PostCriteria>,
            IPostRepository
    {
        protected override string CacheKeyPrefix => "posts";

        public PostRepository(BlogDbContext context, IFusionCache cache)
            : base(context, new LinqCriteriaConverter(), new PostMapper(), cache) { }

        public override async ValueTask<Post?> Find(Guid id)
        {
            return await _cache.GetOrSetAsync(
                GetEntityCacheKey(id),
                async _ => await base.Find(id),
                options => options.SetDuration(TimeSpan.FromMinutes(10)),
                tags: EntityCacheTags
            );
        }

        public override async ValueTask<IEnumerable<Post>> Find(PostCriteria criteria)
        {
            return await _cache.GetOrSetAsync(
                GetCriteriaCacheKey(criteria),
                async _ => await base.Find(criteria),
                options => options.SetDuration(TimeSpan.FromMinutes(10)),
                tags: CollectionCacheTags
            );
        }
    }
}
