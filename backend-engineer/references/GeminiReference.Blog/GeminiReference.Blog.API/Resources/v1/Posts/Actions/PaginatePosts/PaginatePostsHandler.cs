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
        public PaginatePostsHandler(PaginatePostsUseCase useCase)
            : base(useCase) { }

        protected override PostCriteria MapCriteria(PaginatePostsRequestDTO request)
        {
            var criteria = base.MapCriteria(request);

            criteria.AddOrder(request.OrderBy.Field.ToString(), request.OrderBy.Type);

            criteria
                .WithTitle(request.Title__EQ)
                .WithContentsContaining(request.Contents__CONTAINS);

            return criteria;
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
        public override ValueTask<IActionResult> Paginate([FromQuery] PaginatePostsRequestDTO request)
        {
            return base.Paginate(request);
        }
    }
}
