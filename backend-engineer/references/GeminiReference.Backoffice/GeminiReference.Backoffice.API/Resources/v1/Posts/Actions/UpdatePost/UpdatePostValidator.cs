using FluentValidation;
using GeminiReference.Backoffice.API.Resources.v1.Posts.Shared.Localization;
using GeminiReference.Backoffice.Modules.Posts.Domain.ValueObjects;
using Microsoft.Extensions.Localization;

namespace GeminiReference.Backoffice.API.Resources.v1.Posts.Actions.UpdatePost
{
    public class UpdatePostValidator : AbstractValidator<UpdatePostRequestDTO>
    {
        public UpdatePostValidator(IStringLocalizer<PostsLocalization> localizer)
        {
            RuleFor(x => x.Title.Value)
                .NotEmpty()
                .WithMessage(localizer["Validation_Title_Required"])
                .MinimumLength(PostTitle.MIN_LENGTH)
                .WithMessage(x =>
                    localizer.GetString("Validation_Title_TooShort", PostTitle.MIN_LENGTH)
                )
                .MaximumLength(PostTitle.MAX_LENGTH)
                .WithMessage(x =>
                    localizer.GetString("Validation_Title_TooLong", PostTitle.MAX_LENGTH)
                )
                .When(x => x.Title.HasValue);

            RuleFor(x => x.Contents.Value)
                .NotEmpty()
                .WithMessage(localizer["Validation_Contents_Required"])
                .MinimumLength(PostContents.MIN_LENGTH)
                .WithMessage(x =>
                    localizer.GetString("Validation_Contents_TooShort", PostContents.MIN_LENGTH)
                )
                .MaximumLength(PostContents.MAX_LENGTH)
                .WithMessage(x =>
                    localizer.GetString("Validation_Contents_TooLong", PostContents.MAX_LENGTH)
                )
                .When(x => x.Contents.HasValue);
        }
    }
}
