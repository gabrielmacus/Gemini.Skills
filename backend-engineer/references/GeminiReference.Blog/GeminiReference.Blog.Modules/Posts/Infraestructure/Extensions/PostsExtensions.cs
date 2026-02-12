using GeminiReference.Blog.Modules.Posts.Application.UseCases.PaginatePosts;
using GeminiReference.Blog.Modules.Posts.Domain.Contracts;
using GeminiReference.Blog.Modules.Posts.Domain.Services;
using GeminiReference.Blog.Modules.Posts.Infraestructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Neuraltech.SharedKernel.Infraestructure.Extensions;
using ZiggyCreatures.Caching.Fusion;

namespace GeminiReference.Blog.Modules.Posts.Infraestructure.Extensions
{
    public static class PostsExtensions
    {
        public static IHostApplicationBuilder UsePostsModule(this IHostApplicationBuilder builder)
        {
            AddUseCases(builder.Services);
            AddServices(builder.Services);
            AddExceptionHandlers(builder.Services);
            AddCache(builder);

            return builder;
        }

        private static void AddCache(IHostApplicationBuilder builder)
        {
            builder.UseFusionCache("Blog.Posts");
        }

        private static void AddExceptionHandlers(IServiceCollection services)
        {
            //services.AddExceptionHandler()
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddKeyedScoped<IPostRepository, PostRepository>("uncached");
            services.AddScoped<IPostRepository, PostCachedRepository>();

            services.AddScoped<PostFinder>();
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<PaginatePostsUseCase>();
        }
    }
}
