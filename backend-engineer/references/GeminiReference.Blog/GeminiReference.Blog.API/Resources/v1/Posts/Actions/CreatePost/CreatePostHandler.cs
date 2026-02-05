using GeminiReference.Blog.API.Resources.v1.Posts.Shared.Routes;
using GeminiReference.Blog.Modules.Posts.Application.UseCases.CreatePost;
using GeminiReference.Blog.Modules.Posts.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Neuraltech.SharedKernel.Infraestructure.Handlers;

namespace GeminiReference.Blog.API.Resources.v1.Posts.Actions.CreatePost
{
    public class CreatePostHandler : CreateHandler<CreatePostRequestDTO, Post>
    {
        public CreatePostHandler(CreatePostUseCase useCase)
            : base(useCase) { }

        [HttpPost(PostsRoutes.Create)]
        public override ValueTask<IActionResult> Create([FromBody] CreatePostRequestDTO request)
        {
            return base.Create(request);
        }

        protected override Post MapUseCaseRequest(CreatePostRequestDTO request)
        {
            return Post.Create(Guid.Parse(request.Id), request.Title, request.Contents);
        }
    }
}
