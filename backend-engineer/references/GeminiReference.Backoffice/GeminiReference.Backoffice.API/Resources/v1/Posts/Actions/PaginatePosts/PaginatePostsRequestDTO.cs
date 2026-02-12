using GeminiReference.Backoffice.Modules.Posts.Domain.Criteria;
using Neuraltech.SharedKernel.Application.UseCases.Paginate;
using Neuraltech.SharedKernel.Domain.Base.Criteria.Ordering;
using Neuraltech.SharedKernel.Infraestructure.DTO;

namespace GeminiReference.Backoffice.API.Resources.v1.Posts.Actions.PaginatePosts
{
    public record PaginatePostsRequestDTO : PaginateRequestDTO
    {
        public OptionalParam<string> Title__EQ { get; init; }
        public OptionalParam<string> Contents__CONTAINS { get; init; }

        public PaginateOrderBy<PaginatePostsOrderFields> OrderBy { get; init; } = new PaginateOrderBy<PaginatePostsOrderFields>
        {
            Field = PaginatePostsOrderFields.Title,
            Type = OrderTypes.ASC,
        };
    }
}
