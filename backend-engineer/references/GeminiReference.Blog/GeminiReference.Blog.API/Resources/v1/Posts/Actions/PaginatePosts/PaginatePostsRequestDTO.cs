using Neuraltech.SharedKernel.Domain.Base.Criteria.Ordering;
using Neuraltech.SharedKernel.Infraestructure.DTO;

namespace GeminiReference.Blog.API.Resources.v1.Posts.Actions.PaginatePosts
{
    public record PaginatePostsRequestDTO : PaginateRequestDTO
    {
        public required OptionalParam<string> Title__EQ { get; init; }

        public required OptionalParam<string> Contents__CONTAINS { get; init; }
        public PaginateOrderBy<PaginatePostsOrderFields> OrderBy { get; init; } =
            new() { Field = PaginatePostsOrderFields.Id, Type = OrderTypes.DESC };
    }
}
