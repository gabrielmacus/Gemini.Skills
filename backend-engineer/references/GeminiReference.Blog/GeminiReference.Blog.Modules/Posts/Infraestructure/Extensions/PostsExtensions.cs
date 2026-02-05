using GeminiReference.Blog.Modules.Posts.Application.UseCases.CreatePost;
using GeminiReference.Blog.Modules.Posts.Application.UseCases.DeletePost;
using GeminiReference.Blog.Modules.Posts.Application.UseCases.PaginatePosts;
using GeminiReference.Blog.Modules.Posts.Application.UseCases.UpdatePost;
using GeminiReference.Blog.Modules.Posts.Domain.Contracts;
using GeminiReference.Blog.Modules.Posts.Domain.Services;
using GeminiReference.Blog.Modules.Posts.Infraestructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wolverine;

namespace GeminiReference.Blog.Modules.Posts.Infraestructure.Extensions
{
    public static class PostsExtensions
    {
        public static IHostApplicationBuilder UsePostsModule(
            this IHostApplicationBuilder builder
        )
        {
            AddUseCases(builder.Services);
            AddServices(builder.Services);
            AddWolverineExtensions(builder.Services);

            return builder;
        }

        private static void AddWolverineExtensions(IServiceCollection services)
        {
            services.AddWolverineExtension<PostsWolverineExtension>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<PostFinder>();
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<CreatePostUseCase>();
            services.AddScoped<UpdatePostUseCase>();
            services.AddScoped<DeletePostUseCase>();
            services.AddScoped<PaginatePostsUseCase>();
        }
    }
}
