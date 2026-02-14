using FluentValidation;
using GeminiReference.Blog.Modules.Posts.Domain.Criteria;
using Microsoft.Extensions.Localization;
using Neuraltech.SharedKernel.Infraestructure.Localization;

namespace GeminiReference.Blog.API.Resources.v1.Posts.Actions.PaginatePosts
{
    public class PaginatePostsValidator : AbstractValidator<PaginatePostsRequestDTO>
    {
        public PaginatePostsValidator(IStringLocalizer<SharedLocalization> localizer)
        {
            RuleFor(x => x.Page.Value)
                .GreaterThan(0)
                .WithMessage(localizer["Validation_QueryPage_ZeroOrLess"])
                .LessThanOrEqualTo(PostPagination.MaxPageLimit)
                .WithMessage(x =>
                    localizer.GetString(
                        "Validation_QueryPage_ExceedsMax",
                        PostPagination.MaxPageLimit
                    )
                )
                .When(x => x.Page.HasValue);

            RuleFor(x => x.Limit.Value)
                .GreaterThan(0)
                .WithMessage(localizer["Validation_QueryLimit_ZeroOrLess"])
                .LessThanOrEqualTo(PostPagination.MaxSizeLimit)
                .WithMessage(x =>
                    localizer.GetString(
                        "Validation_QueryLimit_ExceedsMax",
                        PostPagination.MaxSizeLimit
                    )
                )
                .When(x => x.Limit.HasValue);
        }
    }
}
