using FluentValidation;
using GeminiReference.Blog.API.Resources.v1.Posts.Shared.Routes;
using GeminiReference.Blog.Modules.Posts.Application.UseCases.PaginatePosts;
using GeminiReference.Blog.Modules.Posts.Domain.Criteria;
using GeminiReference.Blog.Modules.Posts.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Neuraltech.SharedKernel.Infraestructure.Handlers;

namespace GeminiReference.Blog.API.Resources.v1.Posts.Actions.PaginatePosts
{
    public class PaginatePostsHandler
        : PaginateHandler<Post, PostCriteria, PaginatePostsRequestDTO, PaginatePostsResponseDTO>
    {
        public PaginatePostsHandler(
            PaginatePostsUseCase useCase, 
            IValidator<PaginatePostsRequestDTO> validator
        )
            : base(useCase, validator) { }


        protected override PostCriteria MapCriteria(PaginatePostsRequestDTO request, PostCriteria baseCriteria)
        {
            baseCriteria.AddOrder(request.OrderBy.Field.ToString(), request.OrderBy.Type);

            baseCriteria
                .WithTitle(request.Title__EQ)
                .WithContentsContaining(request.Contents__CONTAINS);

            return baseCriteria;
        }

        protected override PaginatePostsResponseDTO MapResponseEntity(Post entity)
        {
            return new PaginatePostsResponseDTO
            {
                Id = entity.Id.Value,
                Title = entity.Title.Value,
                Contents = entity.Contents.Value,
            };
        }

        [HttpGet(PostsRoutes.Paginate)]
        public override ValueTask<IActionResult> Paginate(
            [FromQuery] PaginatePostsRequestDTO request
        )
        {
            return base.Paginate(request);
        }

    }
}
