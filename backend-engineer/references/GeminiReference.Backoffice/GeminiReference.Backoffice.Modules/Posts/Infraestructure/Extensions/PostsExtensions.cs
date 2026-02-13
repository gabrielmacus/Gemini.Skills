using GeminiReference.Backoffice.Modules.Posts.Application.IntegrationEventPublishers.PublishPostCreatedIntegrationEvent;
using GeminiReference.Backoffice.Modules.Posts.Application.IntegrationEventPublishers.PublishPostDeletedIntegrationEvent;
using GeminiReference.Backoffice.Modules.Posts.Application.IntegrationEventPublishers.PublishPostUpdatedIntegrationEvent;
using GeminiReference.Backoffice.Modules.Posts.Application.SnapshotPublishers.PublishPostSnapshot;
using GeminiReference.Backoffice.Modules.Posts.Application.UseCases.CreatePost;
using GeminiReference.Backoffice.Modules.Posts.Application.UseCases.DeletePost;
using GeminiReference.Backoffice.Modules.Posts.Application.UseCases.PaginatePosts;
using GeminiReference.Backoffice.Modules.Posts.Application.UseCases.UpdatePost;
using GeminiReference.Backoffice.Modules.Posts.Domain.Contracts;
using GeminiReference.Backoffice.Modules.Posts.Infraestructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Neuraltech.SharedKernel.Infraestructure.Extensions;
using Wolverine;

namespace GeminiReference.Backoffice.Modules.Posts.Infraestructure.Extensions
{
    public static class PostsExtensions
    {
        public static IHostApplicationBuilder UsePostsModule(this IHostApplicationBuilder builder)
        {
            AddUseCases(builder.Services);
            AddServices(builder.Services);
            AddWolverineExtensions(builder.Services);
            AddExceptionHandlers(builder.Services);
            AddCache(builder);

            return builder;
        }

        private static void AddCache(IHostApplicationBuilder builder)
        {
            builder.UseFusionCache("Backoffice.Posts");
        }

        private static void AddExceptionHandlers(IServiceCollection services)
        {
            //services.AddExceptionHandler()
        }

        private static void AddWolverineExtensions(IServiceCollection services)
        {
            services.AddWolverineExtension<PostsWolverineExtension>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddKeyedScoped<IPostRepository, PostRepository>("uncached");
            services.AddScoped<IPostRepository, PostCachedRepository>();
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<CreatePostUseCase>();
            services.AddScoped<UpdatePostUseCase>();
            services.AddScoped<DeletePostUseCase>();
            services.AddScoped<PaginatePostsUseCase>();

            services.AddScoped<PublishPostCreatedIntegrationEventUseCase>();
            services.AddScoped<PublishPostUpdatedIntegrationEventUseCase>();
            services.AddScoped<PublishPostDeletedIntegrationEventUseCase>();

            services.AddScoped<PostSnapshotPublisher>();
        }
    }
}
