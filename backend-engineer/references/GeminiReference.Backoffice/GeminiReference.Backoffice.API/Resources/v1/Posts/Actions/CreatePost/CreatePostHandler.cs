using FluentValidation;
using GeminiReference.Backoffice.API.Resources.v1.Posts.Shared.Routes;
using GeminiReference.Backoffice.Modules.Posts.Application.UseCases.CreatePost;
using GeminiReference.Backoffice.Modules.Posts.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Neuraltech.SharedKernel.Infraestructure.Handlers;

namespace GeminiReference.Backoffice.API.Resources.v1.Posts.Actions.CreatePost
{
    public class CreatePostHandler : CreateHandler<CreatePostRequestDTO, CreatePostDTO, Post>
    {
        public CreatePostHandler(
            CreatePostUseCase useCase,
            IValidator<CreatePostRequestDTO> validator
        )
            : base(useCase, validator) { }

        [HttpPost(PostsRoutes.Create)]
        public override ValueTask<IActionResult> Create([FromBody] CreatePostRequestDTO request)
        {
            return base.Create(request);
        }

        protected override CreatePostDTO MapUseCaseRequest(CreatePostRequestDTO request)
        {
            return new CreatePostDTO
            {
                Id = Guid.Parse(request.Id),
                Title = request.Title,
                Contents = request.Contents,
            };
        }
    }
}
